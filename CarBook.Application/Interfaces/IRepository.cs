namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Count();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
