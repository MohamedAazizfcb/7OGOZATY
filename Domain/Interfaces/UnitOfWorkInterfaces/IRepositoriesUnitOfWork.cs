using Domain.Interfaces.GenericrRepositoryInterfaces;

namespace Domain.Interfaces.UnitOfWorkInterfaces
{
    public interface IRepositoriesUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
