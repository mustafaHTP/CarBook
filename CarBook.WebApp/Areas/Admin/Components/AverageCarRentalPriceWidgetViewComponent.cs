using CarBook.Application.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class AverageCarRentalPriceWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AverageCarRentalPriceWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(params string[] rentalPeriods)
        {
            string query = string.Empty;
            if (rentalPeriods != null && rentalPeriods.Length != 0)
            {
                query = string.Join(',', rentalPeriods);
            }

            var apiEndpoint = "https://localhost:7116/api/Statistics/carRentalPrice/avg";
            var url = string.IsNullOrEmpty(query)
                ? apiEndpoint
                : $"{apiEndpoint}?rentalPeriods={query}";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetAverageCarRentalPriceDto>(content);

                ViewBag.RentalPeriods = query;

                return View(result);
            }
            else
            {
                return View(new GetAverageCarRentalPriceDto());
            }
        }
    }
}
