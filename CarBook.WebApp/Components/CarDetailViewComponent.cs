using CarBook.Application.Dtos.CarDtos;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarDetailViewComponent : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public CarDetailViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Cars/{carId}?IncludeModel=true&IncludeBrand=true");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetCarByIdDto>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}

