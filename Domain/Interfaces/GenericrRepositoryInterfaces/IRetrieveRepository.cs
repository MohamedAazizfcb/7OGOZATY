using System.Linq.Expressions;

namespace Domain.Interfaces.GenericrRepositoryInterfaces
{
    public interface IRetrieveRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null!);
        Task<T?> GetAsync(Expression<Func<T, object>>[] includes = null!, Expression<Func<T, bool>> filter = null!);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[] includes = null!, Expression<Func<T, bool>> filter = null!);
        T GetById(int id);
        Task<T?> GetByIdAsync(int id, Expression<Func<T, object>>[] includes = null!);
    }
}
