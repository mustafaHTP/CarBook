using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.WebApp.Areas.Admin.Models.BannerModels;
using CarBook.WebApp.Areas.Admin.Models.BlogAuthorModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogAuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogAuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/BlogAuthors");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetBlogAuthorsDto>>(jsonData);

                return View(result);
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogAuthorViewModel createBlogAuthorViewModel)
        {
            var createBlogAuthorDto = new CreateBlogAuthorDto
            {
                Name = createBlogAuthorViewModel.Name,
                Description = createBlogAuthorViewModel.Description,
                ImageUrl = createBlogAuthorViewModel.ImageUrl
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBlogAuthorDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/BlogAuthors", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createBlogAuthorDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/BlogAuthors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBlogAuthorByIdDto>(jsonData);

                var updateBlogAuthorViewModel = new UpdateBlogAuthorViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    ImageUrl = result.ImageUrl
                };

                return View(updateBlogAuthorViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogAuthorViewModel updateBlogAuthorViewModel)
        {
            UpdateBlogAuthorDto updateBlogAuthorDto = new()
            {
                Name = updateBlogAuthorViewModel.Name,
                Description = updateBlogAuthorViewModel.Description,
                ImageUrl = updateBlogAuthorViewModel.ImageUrl
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogAuthorDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/BlogAuthors/{updateBlogAuthorViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogAuthorViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/BlogAuthors/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
