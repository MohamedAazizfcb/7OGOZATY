using Domain.Interfaces.GenericrRepositoryInterfaces;
namespace Infrastructure.Repository.Implementations
{
    public partial class GenericRepository<T>: IUpdateRepository<T>
    {
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public T Update(int id, T updatedEntity)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return null!;

            UpdateEntityFromDto(entity, updatedEntity);
            _dbSet.Update(entity);
            return entity;
        }

        private void UpdateEntityFromDto(T entity, T updatedDto)
        {
            foreach (var property in _propertyInfos)
            {
                var updatedValue = property.GetValue(updatedDto);
                if (updatedValue != null)
                {
                    property.SetValue(entity, updatedValue);
                }
            }
        }
    }
}
