using Domain.Interfaces.GenericrRepositoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Infrastructure.Repository.Implementations;

namespace Infrastructure.UnitOfWorkImplementation
{
    public partial class UnitOfWork : IRepositoryUnitOfWork
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
