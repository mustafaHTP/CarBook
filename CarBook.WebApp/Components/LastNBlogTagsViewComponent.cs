using CarBook.Application.Dtos.BlogTagDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class LastNBlogTagsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LastNBlogTagsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync($"https://localhost:7116/api/BlogTags/last/{count}");

            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLastNBlogTagsDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
