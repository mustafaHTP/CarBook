using CarBook.Application.Dtos.AboutDtos;
using CarBook.Application.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace CarBook.WebApp.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Testimonials/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var value = await response.Content.ReadAsStringAsync();
                var jsonContent = JsonConvert.DeserializeObject<List<GetTestimonialsDto>>(value);

                return View(jsonContent);
            }

            return View();
        }
    }
}
