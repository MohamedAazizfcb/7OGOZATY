using Domain.Results;

namespace Domain.Interfaces
{
    public interface ILookupService<T> where T : class
    {
        Task<OperationResultSingle<T>> CreateAsync(T entity);
        Task<OperationResultSingle<IEnumerable<T>>> GetAllAsync();
        Task<OperationResultSingle<T>> GetByIdAsync(int id);
        Task<OperationResultSingle<T>> UpdateAsync(int id, T entity);
        Task<OperationResultSingle<T>> DeleteAsync(int id);
    }
}
