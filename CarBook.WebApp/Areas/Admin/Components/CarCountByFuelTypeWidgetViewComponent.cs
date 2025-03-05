using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarCountByFuelTypeWidgetViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarCountByFuelTypeWidgetViewComponent(IApiService apiService)
        {
            _apiService = apiService;
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

            var response = await _apiService.GetAsync<GetCarCountByFuelTypeDto>(url);
            if (response.IsSuccessful)
            {
                ViewBag.FuelTypes = query;

                return View(response.Result);
            }
            else
            {
                return View(new GetCarCountByFuelTypeDto());
            }
        }
    }
}
