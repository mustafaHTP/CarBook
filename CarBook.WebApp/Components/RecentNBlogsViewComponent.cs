using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CarBook.WebApp.Components
{
    public class RecentNBlogsViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public RecentNBlogsViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int limit)
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogsDto>>($"https://localhost:7116/api/Blogs?Limit={limit}&DescendingOrder=true&Includes=author");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
