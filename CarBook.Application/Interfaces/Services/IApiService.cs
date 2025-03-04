namespace CarBook.Application.Interfaces.Services
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string url) where T : class;
    }
}
