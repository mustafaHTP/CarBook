using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class Last3BlogsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public Last3BlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Blogs/Last3Blogs");
            if (response.IsSuccessStatusCode)
            {
                var blogs = await response.Content.ReadAsAsync<List<GetLast3BlogsWithAuthorAndCategoryDto>>();

                return View(blogs);
            }

            return View();
        }
    }
}
