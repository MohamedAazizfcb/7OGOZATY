namespace Infrastructure.Repository.Interfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
