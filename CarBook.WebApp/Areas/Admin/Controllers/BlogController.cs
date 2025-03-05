using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BlogModels;
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
        private readonly IApiService _apiService;

        public BlogController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogsDto>>("https://localhost:7116/api/Blogs?Includes=author,category");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public async Task<IActionResult> GetBlogCommentsById(int id)
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogCommentsByBlogIdDto>>($"https://localhost:7116/api/Blogs/{id}/comments");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public async Task<IActionResult> GetBlogTagsById(int id)
        {
            ViewData["BlogId"] = id;

            var response = await _apiService.GetAsync<IEnumerable<GetBlogTagsByIdDto>>($"https://localhost:7116/api/Blogs/{id}/tags");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
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

            var json = JsonConvert.SerializeObject(createBlogDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Blogs", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createBlogDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBlogByIdDto>($"https://localhost:7116/api/Blogs/{id}?Includes=author,category");

            if (response.IsSuccessful && response.Result is not null)
            {
                ViewBag.BlogCategorySelectList = await GetBlogCategorySelectList();
                ViewBag.BlogAuthorSelectList = await GetBlogAuthorSelectList();

                var updateBlogViewModel = new UpdateBlogViewModel()
                {
                    Id = response.Result.Id,
                    Title = response.Result.Title,
                    Description = response.Result.Description,
                    Content = response.Result.Content,
                    CoverImageUrl = response.Result.CoverImageUrl,
                    BlogAuthorId = response.Result.BlogAuthorId,
                    BlogCategoryId = response.Result.BlogCategoryId
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

            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Blogs/{updateBlogViewModel.Id}", content);

            if (response.IsSuccessful)
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
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Blogs/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetBlogCategorySelectList()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogCategoriesDto>>("https://localhost:7116/api/BlogCategories");

            IEnumerable<SelectListItem>? blogCategorySelectList = null;
            if (response.IsSuccessful)
            {
                blogCategorySelectList = response.Result?.Select(bc => new SelectListItem()
                {
                    Value = bc.Id.ToString(),
                    Text = bc.Name
                });
            }

            return await Task.FromResult(blogCategorySelectList);
        }

        private async Task<IEnumerable<SelectListItem>?> GetBlogAuthorSelectList()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogAuthorsDto>>("https://localhost:7116/api/BlogAuthors");

            IEnumerable<SelectListItem>? blogAuthorSelectList = null;
            if (response.IsSuccessful)
            {
                blogAuthorSelectList = response.Result?.Select(bc => new SelectListItem()
                {
                    Value = bc.Id.ToString(),
                    Text = bc.Name
                });
            }

            return await Task.FromResult(blogAuthorSelectList);
        }
    }
}
