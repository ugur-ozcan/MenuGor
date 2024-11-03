// QRMenu.Infrastructure/Extensions/ServiceCollectionExtensions.cs
// QRMenu.Infrastructure/Extensions/ServiceCollectionExtensions.cs
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QRMenu.Infrastructure.Common.Interfaces;
using QRMenu.Infrastructure.Persistence.Contexts;
using QRMenu.Infrastructure.Services;
using QRMenu.Application.Common.Interfaces;

namespace QRMenu.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IDateTime, DateTimeService>();

        return services;
    }
}