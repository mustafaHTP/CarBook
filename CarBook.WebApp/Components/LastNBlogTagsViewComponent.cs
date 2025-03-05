using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class LastNBlogTagsViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public LastNBlogTagsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var response = await _apiService.GetAsync<IEnumerable<GetLastNBlogTagsDto>>($"https://localhost:7116/api/BlogTags/last/{count}");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
