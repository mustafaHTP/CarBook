using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class SidebarBlogCategoriesViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public SidebarBlogCategoriesViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBlogCategoriesDto>>("https://localhost:7116/api/BlogCategories");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
