using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarCountByTransmissionTypeWidgetViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarCountByTransmissionTypeWidgetViewComponent(IApiService apiService)
        {
            _apiService = apiService;
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

            var response = await _apiService.GetAsync<GetCarCountByTransmissionTypeDto>(url);
            if (response.IsSuccessful)
            {
                ViewBag.TransmissionTypes = query;

                return View(response.Result);
            }
            else
            {
                return View(new GetCarCountByTransmissionTypeDto());
            }
        }

    }
}
