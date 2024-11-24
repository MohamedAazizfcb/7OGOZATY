using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Repository.Implementations
{
    public partial class GenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly PropertyInfo[] _propertyInfos;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _propertyInfos = typeof(T).GetProperties();
        }
    }
}
