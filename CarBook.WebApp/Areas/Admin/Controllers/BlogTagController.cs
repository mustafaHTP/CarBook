using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BlogTagModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogTagController : Controller
    {
        private readonly IApiService _apiService;

        public BlogTagController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogTagsDto>>("https://localhost:7116/api/BlogTags");
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
        public async Task<IActionResult> Create(CreateBlogTagViewModel createBlogTagViewModel)
        {
            var createBlogTagDto = new CreateBlogTagDto
            {
                Name = createBlogTagViewModel.Name,
            };

            var json = JsonConvert.SerializeObject(createBlogTagDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/BlogTags", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createBlogTagDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBlogTagByIdDto>($"https://localhost:7116/api/BlogTags/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateBlogTagViewModel = new UpdateBlogTagViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                };

                return View(updateBlogTagViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogTagViewModel updateBlogTagViewModel)
        {
            UpdateBlogTagDto updateBlogTagDto = new()
            {
                Name = updateBlogTagViewModel.Name,
            };

            var jsonData = JsonConvert.SerializeObject(updateBlogTagDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/BlogTags/{updateBlogTagViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogTagViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/BlogTags/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
