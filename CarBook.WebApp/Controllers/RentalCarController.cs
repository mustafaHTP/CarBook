using CarBook.Application.Dtos.RentalCarDtos;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Controllers
{
    public class RentalCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentalCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(RentalCarFilterDto rentalCarFilterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var apiEndpoint = "https://localhost:7116/api/RentalCars";
            var query = $"PickUpLocationId={rentalCarFilterDto.PickUpLocationId}";
            var url = $"{apiEndpoint}?{query}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetRentalCarsDto>>(jsonData);

                return View(result);
            }

            return View();
        }
    }
}
