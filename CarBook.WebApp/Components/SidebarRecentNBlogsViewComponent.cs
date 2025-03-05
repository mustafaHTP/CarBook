using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class SidebarRecentNBlogsViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public SidebarRecentNBlogsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int limit)
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetBlogsDto>>($"https://localhost:7116/api/Blogs?Limit={limit}&DescendingOrder=true&Includes=author");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
