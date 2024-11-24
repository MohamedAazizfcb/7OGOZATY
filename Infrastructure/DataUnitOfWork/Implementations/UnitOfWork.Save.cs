using Infrastructure.DataUnitOfWork.Interfaces;

namespace Infrastructure.DataUnitOfWork.Implementations
{
    public partial class UnitOfWork : ISaveUnitOfWork
    {
        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
