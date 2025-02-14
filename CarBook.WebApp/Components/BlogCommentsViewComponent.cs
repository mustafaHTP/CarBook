using CarBook.Application.Dtos.BlogCommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BlogCommentsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogCommentsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Blogs/{blogId}/comments");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogCommentsByBlogIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
