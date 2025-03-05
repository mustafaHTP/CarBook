using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class CarDetailViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarDetailViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var response = await _apiService.GetAsync<GetCarByIdDto>($"https://localhost:7116/api/Cars/{carId}");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}

