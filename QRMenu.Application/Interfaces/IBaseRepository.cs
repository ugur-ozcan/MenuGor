// QRMenu.Application/Common/Interfaces/IBaseRepository.cs
namespace QRMenu.Application.Common.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<bool> ExistsAsync(Guid id);
}