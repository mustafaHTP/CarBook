using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BlogCategoryModels;
using CarBook.WebApp.Areas.Admin.Models.BlogModels;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogTagController(IApiService apiService, IHttpClientFactory httpClientFactory)
        {
            _apiService = apiService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var blogTags = await _apiService.GetAsync<IEnumerable<GetBlogTagsDto>>("https://localhost:7116/api/BlogTags");

            return View(blogTags);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBlogTagDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/BlogTags", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createBlogTagDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/BlogTags/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBlogTagByIdDto>(jsonData);

                var updateBlogTagViewModel = new UpdateBlogTagViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogTagDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/BlogTags/{updateBlogTagViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogTagViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/BlogTags/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
