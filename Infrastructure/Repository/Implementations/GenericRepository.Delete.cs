using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public partial class GenericRepository<T> : IDeleteRepository<T>
    {
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task DeleteRangeByAsync(Expression<Func<T, bool>> filter)
        {
            await _dbSet.Where(filter).ExecuteDeleteAsync();
        }

        public void SoftDelete(T entity)
        {
            foreach (var property in _propertyInfos)
            {
                if (property.Name == "DeletedDate" && property.CanWrite)
                    property.SetValue(entity, DateTime.UtcNow);
                if (property.Name == "IsActive" && property.CanWrite)
                    property.SetValue(entity, false);
                if (property.Name == "IsDeleted" && property.CanWrite)
                    property.SetValue(entity, true);
            }
            _dbSet.Update(entity);
        }
    }
}
