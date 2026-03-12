using Microsoft.EntityFrameworkCore;
using SEMBS.SEMBS.Data;
using SEMBS.SEMBS.Repository.Contracts;
using System.Linq.Expressions;

namespace SEMBS.SEMBS.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public T GetById(int id) => _dbSet.Find(id);

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}
