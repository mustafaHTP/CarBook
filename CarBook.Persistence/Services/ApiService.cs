using CarBook.Application;
using CarBook.Application.Interfaces.Services;
using CarBook.Application.Responses;
using CarBook.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarBook.Persistence.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GenericApiResponse<T>> GetAsync<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();

            //Get the access token from the HttpContext
            var accessToken = GetAccessToken();
            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return GenericApiResponse<T>.Failure(
                    title: "Failed to get data",
                    status: (int)response.StatusCode,
                    detail: "Failed to get data from the server.");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GenericApiResponse<T>>(jsonData);
            if(result is null)
            {
                return GenericApiResponse<T>.Failure(
                    title: "Failed to deserialize data",
                    status: 500,
                    detail: "Failed to deserialize data from the server.");
            }

            return result;
        }

        public async Task<GenericApiResponse<EmptyApiResult>> PostAsync(string url, HttpContent? data)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await client.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return GenericApiResponse<EmptyApiResult>.Failure(
                    title: "Failed to post data",
                    status: (int)response.StatusCode,
                    detail: "Failed to post data to the server.");
            }

            return GenericApiResponse<EmptyApiResult>.Success();
        }

        public async Task<GenericApiResponse<EmptyApiResult>> PutAsync(string url, HttpContent? data)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await client.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return GenericApiResponse<EmptyApiResult>.Failure(
                    title: "Failed to put data",
                    status: (int)response.StatusCode,
                    detail: "Failed to put data to the server.");
            }

            return GenericApiResponse<EmptyApiResult>.Success();
        }

        public async Task<GenericApiResponse<EmptyApiResult>> DeleteAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return GenericApiResponse<EmptyApiResult>.Failure(
                    title: "Failed to delete data",
                    status: (int)response.StatusCode,
                    detail: "Failed to delete data from the server.");
            }

            return GenericApiResponse<EmptyApiResult>.Success();
        }

        private string? GetAccessToken()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var token = httpContext?.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value?.ToString();
            return token;
        }
    }
}
