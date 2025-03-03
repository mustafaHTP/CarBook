using CarBook.Application.Dtos.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarBook.WebApp.Components
{
    public class SidebarRecentNBlogsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SidebarRecentNBlogsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int limit)
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync($"https://localhost:7116/api/Blogs?Limit={limit}&DescendingOrder=true&Includes=author");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<GetBlogsDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
