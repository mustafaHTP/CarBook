using CarBook.Application;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

        public async Task<ApiResponse<T>> GetAsync<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var accessToken = GetAccessToken();

            if (!string.IsNullOrEmpty(accessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return ApiResponse<T>.CreateResponse(true, $"Failed to get data. Status code: {response.StatusCode}", null);
            }

            T? result;
            var jsonData = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(jsonData);

            return ApiResponse<T>.CreateResponse(true, "Data retrieved successfully", result);
        }

        private string? GetAccessToken()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var token = httpContext?.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value?.ToString();
            return token;
        }
    }
}
