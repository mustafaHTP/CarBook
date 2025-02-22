using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogCommentCountViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogCommentCountViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Statistics/blog/{blogId}/comments/count");
            
            int blogCommentCount = 0;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetBlogCommentCountByBlogIdDto>(jsonData);

                blogCommentCount = value?.BlogCommentCount ?? 0;
            }

            return blogCommentCount.ToString();
        }
    }
}
