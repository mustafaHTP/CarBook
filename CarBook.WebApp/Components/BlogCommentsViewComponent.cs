using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogCommentsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiService _apiService;

        public BlogCommentsViewComponent(IHttpClientFactory httpClientFactory, IApiService apiService)
        {
            _httpClientFactory = httpClientFactory;
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            ViewData["BlogId"] = blogId;

            var values = await _apiService.GetAsync<IEnumerable<GetBlogCommentsByBlogIdDto>>($"https://localhost:7116/api/Blogs/{blogId}/comments");

            return View(values);
        }
    }
}
