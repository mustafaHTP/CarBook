using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Services
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> GetAsync<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);

            var result = default(T);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(jsonData);
            }

            return result;
        }
    }
}
