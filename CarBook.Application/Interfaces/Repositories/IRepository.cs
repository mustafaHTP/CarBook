using System.Linq.Expressions;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        int Count();
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IEnumerable<T?> Where(Expression<Func<T, bool>> predicate);
        T? FirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}
