using CarBook.Application.Dtos.Car;
using CarBook.Application.Dtos.FooterAddress;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class Last5CarsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Last5CarsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Cars/GetLast5CarsWithBrand");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetLast5CarsWithBrandDto>>(jsonData);

                return View(result);
            }

            return View();
        }
    }
}
