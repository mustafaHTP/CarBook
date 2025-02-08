using CarBook.Application.Dtos.BlogTagCloudDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogTagsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogTagsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync($"https://localhost:7116/api/BlogTagClouds/{blogId}/tags");

            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogTagsByBlogIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
