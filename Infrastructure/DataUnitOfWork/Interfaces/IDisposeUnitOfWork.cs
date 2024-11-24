namespace Infrastructure.DataUnitOfWork.Interfaces
{
    public interface IDisposeUnitOfWork :
        IDisposable,
        IAsyncDisposable
    {
    }
}
