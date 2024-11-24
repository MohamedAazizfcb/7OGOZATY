namespace Domain.Interfaces.GenericrRepositoryInterfaces
{
    public interface IUpdateRepository<T> where T : class
    {
        void Update(T entity);
    }
}
