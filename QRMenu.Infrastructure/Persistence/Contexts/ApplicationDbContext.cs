// QRMenu.Infrastructure/Persistence/Contexts/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using QRMenu.Domain.Entities;
using QRMenu.Domain.Common;
using System.Reflection;
using System;
using QRMenu.Infrastructure.Common.Interfaces;
using System.Linq.Expressions;

namespace QRMenu.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService,
        IDateTime dateTime) : base(options)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.CreatedDate = _dateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModifiedDate = _dateTime.Now;
                    break;

                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedBy = _currentUserService.UserId;
                    entry.Entity.DeletedDate = _dateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Soft delete global filter
        foreach (var type in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(type.ClrType))
            {
                var parameter = Expression.Parameter(type.ClrType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var falseConstant = Expression.Constant(false);
                var comparison = Expression.Equal(property, falseConstant);
                var lambda = Expression.Lambda(comparison, parameter);

                modelBuilder.Entity(type.ClrType).HasQueryFilter(lambda);
            }
        }

        base.OnModelCreating(modelBuilder);
    }
}