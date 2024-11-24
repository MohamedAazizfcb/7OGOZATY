using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces
{
    public interface IExistRepository<T> where T : class
    {
        bool Exists(Expression<Func<T, bool>> filter);
    }
}
