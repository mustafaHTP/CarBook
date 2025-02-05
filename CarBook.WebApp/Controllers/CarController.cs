using CarBook.Application.Dtos.CarDtos;
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
            var queryParams = $"?IncludeModel=true&IncludeBrand=true";
            var requestUri = $"https://localhost:7116/api/Cars/GetAll{queryParams}";

            var response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var carsDto = JsonConvert.DeserializeObject<List<GetCarsDto>>(jsonData);

                return View(carsDto);
            }

            return View();
        }
    }
}
