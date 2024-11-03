// QRMenu.Application/Companies/Interfaces/ICompanyRepository.cs
using QRMenu.Application.Common.Interfaces;
using QRMenu.Domain.Entities;

namespace QRMenu.Application.Companies.Interfaces;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<Company> GetByCodeAsync(string code);
    Task<Company> GetWithBranchesAsync(Guid id);
    Task<bool> IsCodeUniqueAsync(string code);
}