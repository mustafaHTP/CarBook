using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.WebApp.Areas.Admin.Models.CarModels;
using CarBook.WebApp.Areas.Admin.Models.RentalPricingModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarRentalPriceListWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarRentalPriceListWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rentalPricings =
                await GetApiResponse<IEnumerable<GetCarRentalPricingsDto>>("https://localhost:7116/api/Cars/RentalPricings?IncludeCar=true");

            return View(rentalPricings);
        }

        private async Task<T?> GetApiResponse<T>(string url) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            return response.IsSuccessStatusCode ? result : null;
        }
    }
}
