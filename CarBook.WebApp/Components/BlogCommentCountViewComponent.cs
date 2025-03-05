using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogCommentCountViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public BlogCommentCountViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> InvokeAsync(int blogId)
        {
            var response = await _apiService.GetAsync<GetBlogCommentCountByIdDto>($"https://localhost:7116/api/Blogs/{blogId}/comments/count");
            int blogCommentCount = 0;
            if (response.IsSuccessful)
            {
                blogCommentCount = response.Result?.BlogCommentCount ?? 0;
            }

            return blogCommentCount.ToString();
        }
    }
}
