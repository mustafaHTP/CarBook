using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
