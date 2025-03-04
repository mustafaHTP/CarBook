using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
            var cars = await _apiService.GetAsync<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");

            return View(cars);
        }

        public IActionResult GetById(int id)
        {
            ViewData["CarId"] = id;

            return View();
        }
    }
}
