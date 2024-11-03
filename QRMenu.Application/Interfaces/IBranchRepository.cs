using System;
using System.Threading.Tasks;
using QRMenu.Domain.Entities;
using QRMenu.Application.Common.Interfaces;

namespace QRMenu.Application.Companies.Interfaces;

public interface IBranchRepository : IBaseRepository<Branch>
{
    Task<Branch> GetByCodeAsync(string companyCode, string branchCode);
    Task<bool> IsCodeUniqueAsync(Guid companyId, string code);
}