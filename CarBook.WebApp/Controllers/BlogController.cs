using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7116/api/Blogs/WithAuthorAndCategory");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogsWithAuthorAndCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> GetById(int id)
        {
            ViewData["BlogId"] = id;

            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync($"https://localhost:7116/api/Blogs/WithAuthor/{id}");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdWithAuthorDto>(jsonData);

                return View(values);
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
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://localhost:7116/api/BlogComments", stringContent);

            return RedirectToAction(nameof(GetById), new { id = createBlogCommentViewModel.BlogId });
        }
    }
}
