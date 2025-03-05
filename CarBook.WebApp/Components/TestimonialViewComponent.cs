using CarBook.Application.Dtos.TestimonialDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public TestimonialViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetTestimonialsDto>>("https://localhost:7116/api/Testimonials");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
