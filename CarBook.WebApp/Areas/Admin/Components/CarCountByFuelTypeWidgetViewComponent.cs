using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarCountByFuelTypeWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarCountByFuelTypeWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(params FuelType[] fuelTypes)
        {
            if (fuelTypes is null)
            {
                return View(new GetCarCountByFuelTypeDto());
            }

            IEnumerable<string> fuelTypeList = fuelTypes.Select(f => f.ToString());

            string? query = string.Join(',', fuelTypeList);
            string apiEndpoint = "https://localhost:7116/api/Statistics/car/countByFuelType";
            string url = string.IsNullOrEmpty(query) ? apiEndpoint : $"{apiEndpoint}?FuelTypes={query}";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetCarCountByFuelTypeDto>(content);

                ViewBag.FuelTypes = query;

                return View(result);
            }
            else
            {
                return View(new GetCarCountByFuelTypeDto());
            }
        }
    }
}
