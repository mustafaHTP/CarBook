using CarBook.Application.Dtos.TestimonialDtos;
using CarBook.WebApp.Areas.Admin.Models.TestimonialModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Testimonials");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetTestimonialsDto>>(jsonData);

                return View(result);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialViewModel createTestimonialViewModel)
        {
            var createTestimonialDto = new CreateTestimonialDto
            {
                Name = createTestimonialViewModel.Name,
                Title = createTestimonialViewModel.Title,
                Comment = createTestimonialViewModel.Comment,
                ImageUrl = createTestimonialViewModel.ImageUrl
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createTestimonialDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Testimonials", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createTestimonialDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Testimonials/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetTestimonialByIdDto>(jsonData);

                var updateTestimonialViewModel = new UpdateTestimonialViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Comment = result.Comment,
                    ImageUrl = result.ImageUrl,
                    Title = result.Title
                };

                return View(updateTestimonialViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialViewModel updateTestimonialViewModel)
        {
            UpdateTestimonialDto updateTestimonialDto = new()
            {
                Name = updateTestimonialViewModel.Name,
                Title = updateTestimonialViewModel.Title,
                Comment = updateTestimonialViewModel.Comment,
                ImageUrl = updateTestimonialViewModel.ImageUrl
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Testimonials/{updateTestimonialViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateTestimonialViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Testimonials/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
