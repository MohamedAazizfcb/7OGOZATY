using Domain.Interfaces.GenericrRepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public partial class GenericRepository<T> : IRetrieveRepository<T>
    {
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter)!;
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            return query.ToList();
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();
            if (filter != null)
                query = query.Where(filter);
            return await query.ToListAsync();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
