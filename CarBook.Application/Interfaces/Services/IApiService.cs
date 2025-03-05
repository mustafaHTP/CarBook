namespace CarBook.Application.Interfaces.Services
{
    public interface IApiService
    {
        Task<ApiResponse<T>> GetAsync<T>(string url) where T : class;
    }
}
