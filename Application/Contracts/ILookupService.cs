using Domain.Results;
using Domain.Entities.Lookups;

namespace Application.Contracts
{
    public interface ILookupService<T> where T : Lookup
    {
        Task<OperationResultSingle<IEnumerable<T>>> GetAllAsync();
        Task<OperationResultSingle<T>> GetByIdAsync(int id);
        Task<OperationResultSingle<T>> AddAsync(T entity);
        Task<OperationResultSingle<T>> UpdateAsync(int id, T newEntity);
        Task<OperationResultSingle<T>> DeleteAsync(int id);
    }
}
