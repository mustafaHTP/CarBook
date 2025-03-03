using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var car = await _apiService.Get<GetCarByIdDto>($"https://localhost:7116/api/Cars/{carId}");

            return View(car);
        }
    }
}

