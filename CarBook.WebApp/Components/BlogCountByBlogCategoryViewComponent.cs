using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class BlogCountByBlogCategoryViewComponent
    {
        private readonly IApiService _apiService;

        public BlogCountByBlogCategoryViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> InvokeAsync(int blogCategoryId)
        {
            var response = await _apiService.GetAsync<GetBlogsCountByIdDto>($"https://localhost:7116/api/BlogCategories/{blogCategoryId}/blogs/count");

            return response.Result?.Count.ToString() ?? "0";
        }
    }
}
