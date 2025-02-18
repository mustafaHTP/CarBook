using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarCountByTransmissionTypeWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarCountByTransmissionTypeWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(params TransmissionType[] transmissionTypes)
        {
            if (transmissionTypes is null)
            {
                return View(new GetCarCountByTransmissionTypeDto());
            }

            IEnumerable<string> transmissionTypeList = transmissionTypes.Select(f => f.ToString());

            string? query = string.Join(',', transmissionTypeList);
            string apiEndpoint = "https://localhost:7116/api/Statistics/car/countByTransmissionType";
            string url = string.IsNullOrEmpty(query) ? apiEndpoint : $"{apiEndpoint}?TransmissionTypes={query}";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetCarCountByTransmissionTypeDto>(content);

                ViewBag.TransmissionTypes = query;

                return View(result);
            }
            else
            {
                return View(new GetCarCountByTransmissionTypeDto());
            }
        }

    }
}
