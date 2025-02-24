using CarBook.Application.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarFeatureSummaryViewComponent : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public CarFeatureSummaryViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Cars/{carId}/CarFeatures");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<GetCarFeaturesByCarIdDto>>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
