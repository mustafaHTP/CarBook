using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.Domain.Entities;
using CarBook.WebApp.Areas.Admin.Models.BlogModels;
using CarBook.WebApp.Areas.Admin.Models.BrandModels;
using CarBook.WebApp.Areas.Admin.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiService _apiService;

        public BlogController(IHttpClientFactory httpClientFactory, IApiService apiService)
        {
            _httpClientFactory = httpClientFactory;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _apiService.GetAsync<IEnumerable<GetBlogsDto>>("https://localhost:7116/api/Blogs?Includes=author,category");

            return View(result);
        }

        public async Task<IActionResult> GetBlogCommentsById(int id)
        {
            var result = await _apiService.GetAsync<IEnumerable<GetBlogCommentsByBlogIdDto>>($"https://localhost:7116/api/Blogs/{id}/comments");

            return View(result);
        }

        public async Task<IActionResult> GetBlogTagsById(int id)
        {
            ViewData["BlogId"] = id;

            var result = await _apiService.GetAsync<IEnumerable<GetBlogTagsByIdDto>>($"https://localhost:7116/api/Blogs/{id}/tags");

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BlogCategorySelectList = await GetBlogCategorySelectList();
            ViewBag.BlogAuthorSelectList = await GetBlogAuthorSelectList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel createBlogViewModel)
        {
            var createBlogDto = new CreateBlogDto
            {
                Title = createBlogViewModel.Title,
                Description = createBlogViewModel.Description,
                Content = createBlogViewModel.Content,
                CoverImageUrl = createBlogViewModel.CoverImageUrl,
                BlogAuthorId = createBlogViewModel.BlogAuthorId,
                BlogCategoryId = createBlogViewModel.BlogCategoryId

            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBlogDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Blogs", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createBlogDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            // Get the blog by id
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Blogs/{id}?Includes=author,category");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.BlogCategorySelectList = await GetBlogCategorySelectList();
                ViewBag.BlogAuthorSelectList = await GetBlogAuthorSelectList();

                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);

                var updateBlogViewModel = new UpdateBlogViewModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    Content = result.Content,
                    CoverImageUrl = result.CoverImageUrl,
                    BlogAuthorId = result.BlogAuthorId,
                    BlogCategoryId = result.BlogCategoryId
                };

                return View(updateBlogViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogViewModel updateBlogViewModel)
        {
            UpdateBlogDto updateBlogDto = new()
            {
                Title = updateBlogViewModel.Title,
                Description = updateBlogViewModel.Description,
                Content = updateBlogViewModel.Content,
                CoverImageUrl = updateBlogViewModel.CoverImageUrl,
                BlogAuthorId = updateBlogViewModel.BlogAuthorId,
                BlogCategoryId = updateBlogViewModel.BlogCategoryId
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Blogs/{updateBlogViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.BlogCategorySelectList = await GetBlogCategorySelectList();
                ViewBag.BlogAuthorSelectList = await GetBlogAuthorSelectList();

                return View(updateBlogViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Blogs/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetBlogCategorySelectList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/BlogCategories");

            IEnumerable<SelectListItem>? blogCategorySelectList = null;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetBlogCategoriesDto>>(jsonData);

                blogCategorySelectList = result?.Select(bc => new SelectListItem()
                {
                    Value = bc.Id.ToString(),
                    Text = bc.Name
                });
            }

            return await Task.FromResult(blogCategorySelectList);
        }

        private async Task<IEnumerable<SelectListItem>?> GetBlogAuthorSelectList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/BlogAuthors");

            IEnumerable<SelectListItem>? blogAuthorSelectList = null;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetBlogAuthorsDto>>(jsonData);

                blogAuthorSelectList = result?.Select(bc => new SelectListItem()
                {
                    Value = bc.Id.ToString(),
                    Text = bc.Name
                });
            }

            return await Task.FromResult(blogAuthorSelectList);
        }
    }
}
