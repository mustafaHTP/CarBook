using CarBook.Application.Dtos.TestimonialDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.TestimonialModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IApiService _apiService;

        public TestimonialController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetTestimonialsDto>>("https://localhost:7116/api/Testimonials");
            if (response.IsSuccessful)
            {
                return View(response.Result);
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

            var json = JsonConvert.SerializeObject(createTestimonialDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Testimonials", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createTestimonialDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetTestimonialByIdDto>($"https://localhost:7116/api/Testimonials/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateTestimonialViewModel = new UpdateTestimonialViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                    Comment = response.Result.Comment,
                    ImageUrl = response.Result.ImageUrl,
                    Title = response.Result.Title
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

            var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Testimonials/{updateTestimonialViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateTestimonialViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Testimonials/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
