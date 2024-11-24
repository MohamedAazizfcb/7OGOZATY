using Infrastructure.Repository.Interfaces;

namespace Infrastructure.DataUnitOfWork.Interfaces
{
    public interface IRepositoriesUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
    }
}
