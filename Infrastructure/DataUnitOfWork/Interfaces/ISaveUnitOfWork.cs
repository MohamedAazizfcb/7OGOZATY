namespace Infrastructure.DataUnitOfWork.Interfaces
{
    public interface ISaveUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
    }
}
