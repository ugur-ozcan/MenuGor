// QRMenu.Application/Common/Interfaces/IUnitOfWork.cs
using QRMenu.Application.Companies.Interfaces;

namespace QRMenu.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICompanyRepository Companies { get; }
    IBranchRepository Branches { get; }
    ISocialMediaLinkRepository SocialMediaLinks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}