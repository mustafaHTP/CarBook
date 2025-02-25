using CarBook.Application.Dtos.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarDescriptionSummaryViewComponent : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public CarDescriptionSummaryViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Cars/{carId}/CarDescriptions");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<IEnumerable<GetCarDescriptionsByCarIdDto>>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
