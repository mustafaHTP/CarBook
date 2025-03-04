using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class Last5CarsViewComponent : ViewComponent
    {
        private IApiService _apiService;

        public Last5CarsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carsWithRentalPricings = await _apiService.GetAsync<IEnumerable<GetCarsWithRentalPricingsDto>>("https://localhost:7116/api/Cars/RentalPricings");

            return View(carsWithRentalPricings);
        }
    }
}
