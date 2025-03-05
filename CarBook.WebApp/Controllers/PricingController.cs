using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBook.WebApp.Controllers
{
    public class PricingController : Controller
    {
        private readonly IApiService _apiService;

        public PricingController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
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
