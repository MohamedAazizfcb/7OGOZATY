namespace Infrastructure.DataUnitOfWork.Interfaces
{
    public interface IUnitOfWork :
        ISaveUnitOfWork,
        IRepositoriesUnitOfWork,
        IDisposeUnitOfWork
    {
    }
}
