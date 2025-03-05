namespace CarBook.Application.Interfaces.Services
{
    public interface IApiService
    {
        Task<ApiResponse<T>> GetAsync<T>(string url) where T : class;
        Task<ApiResponse> PostAsync(string url, HttpContent? data);
        Task<ApiResponse> PutAsync(string url, HttpContent? data);
        Task<ApiResponse> DeleteAsync(string url);
    }
}
