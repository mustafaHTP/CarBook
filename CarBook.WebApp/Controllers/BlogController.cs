using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Controllers
{
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

        public async Task<IActionResult> GetById(int id)
        {
            ViewData["BlogId"] = id;

            var response = await _apiService.GetAsync<GetBlogByIdDto>($"https://localhost:7116/api/Blogs/{id}?Includes=author");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync([FromForm] CreateBlogCommentViewModel createBlogCommentViewModel)
        {
            var createBlogCommentDto = new CreateBlogCommentDto()
            {
                BlogId = createBlogCommentViewModel.BlogId,
                Content = createBlogCommentViewModel.Content,
                Email = createBlogCommentViewModel.Email,
                Name = createBlogCommentViewModel.Name,
                CreatedDate = DateTime.Now
            };
            var stringContent = new StringContent(
                JsonConvert.SerializeObject(createBlogCommentDto),
                Encoding.UTF8,
                "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/BlogComments", stringContent);

            return RedirectToAction(nameof(GetById), new { id = createBlogCommentViewModel.BlogId });
        }
    }
}
