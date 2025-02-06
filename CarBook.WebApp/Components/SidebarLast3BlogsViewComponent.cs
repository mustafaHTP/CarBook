using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class SidebarLast3BlogsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SidebarLast3BlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7116/api/Blogs/Last3Blogs");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetLast3BlogsWithAuthorAndCategoryDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
