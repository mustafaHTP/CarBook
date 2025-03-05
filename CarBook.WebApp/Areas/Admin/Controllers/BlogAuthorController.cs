using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BlogAuthorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogAuthorController : Controller
    {
        private readonly IApiService _apiService;

        public BlogAuthorController(IHttpClientFactory httpClientFactory, IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogAuthorsDto>>("https://localhost:7116/api/BlogAuthors");
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
        public async Task<IActionResult> Create(CreateBlogAuthorViewModel createBlogAuthorViewModel)
        {
            var createBlogAuthorDto = new CreateBlogAuthorDto
            {
                Name = createBlogAuthorViewModel.Name,
                Description = createBlogAuthorViewModel.Description,
                ImageUrl = createBlogAuthorViewModel.ImageUrl
            };

            var json = JsonConvert.SerializeObject(createBlogAuthorDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/BlogAuthors", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }

            return View(createBlogAuthorDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBlogAuthorByIdDto>($"https://localhost:7116/api/BlogAuthors/{id}");

            if (response.IsSuccessful && response.Result is not null)
            {
                var updateBlogAuthorViewModel = new UpdateBlogAuthorViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                    Description = response.Result.Description,
                    ImageUrl = response.Result.ImageUrl
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

            var jsonData = JsonConvert.SerializeObject(updateBlogAuthorDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/BlogAuthors/{updateBlogAuthorViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBlogAuthorViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _apiService.DeleteAsync($"https://localhost:7116/api/BlogAuthors/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
