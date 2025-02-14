using CarBook.Application.Dtos.BlogCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class SidebarBlogCategoriesViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SidebarBlogCategoriesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7116/api/BlogCategories");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBlogCategoriesDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
