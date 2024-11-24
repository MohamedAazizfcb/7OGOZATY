using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces
{
    public interface IRetrieveRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null!);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!);
        T GetById(int id);
        Task<T?> GetByIdAsync(int id);
    }
}
