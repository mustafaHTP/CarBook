using CarBook.Application.Dtos.CarReviewDtos;
using CarBook.Application.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarReviewCountViewComponent : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public CarReviewCountViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response =
                await client.GetAsync($"https://localhost:7116/api/Statistics/car/{carId}/carReviews/count");

            int carReviewCount = 0;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetCarReviewsCountByCarIdDto>(jsonData);

                carReviewCount = value?.CarReviewCount ?? 0;
            }

            return carReviewCount.ToString();
        }
    }
}
