using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces
{
    public interface IDeleteRepository<T> where T : class
    {
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task DeleteRangeByAsync(Expression<Func<T, bool>> filter);
    }
}
