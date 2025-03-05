using CarBook.Application.Dtos.BlogTagCloudDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogTagsViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public BlogTagsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogTagsByBlogIdDto>>($"https://localhost:7116/api/BlogTagClouds/{blogId}/tags");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
