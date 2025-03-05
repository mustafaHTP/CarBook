using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BlogCategoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IApiService _apiService;

        public BlogCategoryController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogCategoriesDto>>("https://localhost:7116/api/BlogCategories");
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
        public async Task<IActionResult> Create(CreateBlogCategoryViewModel createBlogCategoryViewModel)
        {
            var createBlogCategoryDto = new CreateBlogCategoryDto
            {
                Name = createBlogCategoryViewModel.Name,
            };

            var json = JsonConvert.SerializeObject(createBlogCategoryDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiService.PostAsync("https://localhost:7116/api/BlogCategories", content);

            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }

            return View(createBlogCategoryDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBlogCategoryByIdDto>($"https://localhost:7116/api/BlogCategories/{id}");

            if (response.IsSuccessful && response.Result is not null)
            {
                var updateBlogCategoryViewModel = new UpdateBlogCategoryViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                };

                return View(updateBlogCategoryViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogCategoryViewModel updateBlogCategoryViewModel)
        {
            UpdateBlogCategoryDto updateBlogCategoryDto = new()
            {
                Name = updateBlogCategoryViewModel.Name,
            };

            var jsonData = JsonConvert.SerializeObject(updateBlogCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _apiService.PutAsync($"https://localhost:7116/api/BlogCategories/{updateBlogCategoryViewModel.Id}", content);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogCategoryViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _apiService.DeleteAsync($"https://localhost:7116/api/BlogCategories/{id}");

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
