using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Controllers
{
    public class CarController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var requestUri = $"https://localhost:7116/api/Cars?IncludeModel=true&IncludeBrand=true";

            var response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<GetCarsDto>>(jsonData);

                return View(values);
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
