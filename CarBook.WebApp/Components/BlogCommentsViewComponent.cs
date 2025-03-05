using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class BlogCommentsViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public BlogCommentsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            ViewData["BlogId"] = blogId;

            var response = await _apiService.GetAsync<IEnumerable<GetBlogCommentsByBlogIdDto>>($"https://localhost:7116/api/Blogs/{blogId}/comments");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
