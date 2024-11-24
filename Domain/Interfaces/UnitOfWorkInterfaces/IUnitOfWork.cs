namespace Domain.Interfaces.UnitOfWorkInterfaces
{
    public interface IUnitOfWork :
        ISaveUnitOfWork,
        IRepositoriesUnitOfWork,
        IDisposeUnitOfWork
    {
    }
}
