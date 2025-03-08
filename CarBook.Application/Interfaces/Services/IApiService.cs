using CarBook.Application.Responses;
using CarBook.WebApi.Responses;

namespace CarBook.Application.Interfaces.Services
{
    public interface IApiService
    {
        Task<GenericApiResponse<T>> GetAsync<T>(string url) where T : class;
        Task<GenericApiResponse<EmptyApiResult>> PostAsync(string url, HttpContent? data);
        Task<GenericApiResponse<EmptyApiResult>> PutAsync(string url, HttpContent? data);
        Task<GenericApiResponse<EmptyApiResult>> DeleteAsync(string url);
    }
}
