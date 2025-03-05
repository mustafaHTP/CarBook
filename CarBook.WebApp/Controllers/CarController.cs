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
            var response = await _apiService.GetAsync<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public IActionResult GetById(int id)
        {
            ViewData["CarId"] = id;

            return View();
        }
    }
}
