using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Application.Interfaces;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBook.WebApp.Controllers
{
    public class CarController : Controller
    {
        private IApiService _apiService;

        public CarController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _apiService.Get<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");

            return View(cars);
        }

        public IActionResult GetById(int id)
        {
            ViewData["CarId"] = id;

            return View();
        }
    }
}
