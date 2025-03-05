using CarBook.Application.Dtos.RentalCarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBook.WebApp.Controllers
{
    public class RentalCarController : Controller
    {
        private readonly IApiService _apiService;

        public RentalCarController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(RentalCarFilterDto rentalCarFilterDto)
        {
            var baseUrl = "https://localhost:7116/api/RentalCars";
            var query = $"PickUpLocationId={rentalCarFilterDto.PickUpLocationId}";
            var url = $"{baseUrl}?{query}";

            var response = await _apiService.GetAsync<IEnumerable<GetRentalCarsDto>>(url);
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
