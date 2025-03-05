using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
            var response = await _apiService.GetAsync<IEnumerable<GetCarsWithRentalPricingsDto>>("https://localhost:7116/api/Cars/RentalPricings");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
