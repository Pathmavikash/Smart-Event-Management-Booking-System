using System.Linq.Expressions;

namespace SEMBS.SEMBS.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        Task<bool> AddAsync(T entity);    
        Task<bool> UpdateAsync(T entity); 
        Task<bool> DeleteAsync(int id);   
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
    }
}
