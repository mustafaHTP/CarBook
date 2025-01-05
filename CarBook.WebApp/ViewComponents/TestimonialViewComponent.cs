using CarBook.Application.Dtos.About;
using CarBook.Application.Dtos.Testimonial;
using Microsoft.AspNetCore.Mvc;

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
                var testimonials = await response.Content.ReadFromJsonAsync<List<GetTestimonialDto>>();

                return View(testimonials);
            }

            return View();
        }
    }
}
