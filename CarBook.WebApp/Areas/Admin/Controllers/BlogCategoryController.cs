using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.WebApp.Areas.Admin.Models.BlogAuthorModels;
using CarBook.WebApp.Areas.Admin.Models.BlogCategoryModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7116/api/BlogCategories");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogCategoriesDto>>(jsonData);

                return View(values);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBlogCategoryDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/BlogCategories", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createBlogCategoryDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/BlogCategories/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBlogCategoryByIdDto>(jsonData);

                var updateBlogCategoryViewModel = new UpdateBlogCategoryViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/BlogCategories/{updateBlogCategoryViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogCategoryViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/BlogCategories/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
