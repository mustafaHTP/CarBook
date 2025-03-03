using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Controllers
{
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
            var blogs = await _apiService.Get<List<GetBlogsWithAuthorAndCategoryDto>>("https://localhost:7116/api/Blogs/WithAuthorAndCategory");

            return View(blogs);
        }

        public async Task<IActionResult> GetById(int id)
        {
            ViewData["BlogId"] = id;

            var blog = await _apiService.Get<GetBlogByIdWithAuthorDto>($"https://localhost:7116/api/Blogs/WithAuthor/{id}");

            return View(blog);
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
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7116/api/BlogComments", stringContent);

            return RedirectToAction(nameof(GetById), new { id = createBlogCommentViewModel.BlogId });
        }
    }
}
