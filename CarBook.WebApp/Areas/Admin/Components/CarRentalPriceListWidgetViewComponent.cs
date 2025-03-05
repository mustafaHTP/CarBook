using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class CarRentalPriceListWidgetViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarRentalPriceListWidgetViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetCarsWithRentalPricingsDto>>("https://localhost:7116/api/Cars/RentalPricings");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
