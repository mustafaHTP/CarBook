using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarBook.WebApp.Components
{
    public class RecentNBlogsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RecentNBlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int limit)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Blogs?Limit={limit}&DescendingOrder=true&Includes=author");
            if (response.IsSuccessStatusCode)
            {
                var blogs = await response.Content.ReadAsAsync<IEnumerable<GetBlogsDto>>();

                return View(blogs);
            }

            return View();
        }
    }
}
