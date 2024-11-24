using Infrastructure.DataUnitOfWork.Interfaces;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.DataUnitOfWork.Implementations
{
    public partial class UnitOfWork : IRepositoriesUnitOfWork
    {
        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepository<T>)_repositories[typeof(T)];
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }
    }
}
