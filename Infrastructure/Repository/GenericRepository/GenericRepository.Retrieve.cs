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


        public virtual async Task<T?> GetAsync(Expression<Func<T, object>>[] includes = null!, Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            // Apply the filter
            query = query.Where(filter);

            // Include related entities using the includes
            if (includes!=null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Execute the query and return the first or default result
            return await query.FirstOrDefaultAsync();
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>>[] includes = null!, Expression<Func<T, bool>> filter = null!)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            // Apply the filter if it's provided
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include related entities using the includes
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Execute the query and return the result
            return await query.ToListAsync();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public virtual async Task<T?> GetByIdAsync(int id, Expression<Func<T, object>>[] includes = null!)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            // Include related entities using the includes
            if (includes != null && includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Execute the query and return the entity with the specified ID
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
    }
}
