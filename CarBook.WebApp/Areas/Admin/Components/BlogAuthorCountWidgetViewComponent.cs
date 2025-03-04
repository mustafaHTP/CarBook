using CarBook.Application.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class BlogAuthorCountWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogAuthorCountWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Statistics/blogAuthor/count");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBlogAuthorCountDto>(content);

                return View(result);
            }
            else
            {
                return View(new GetBlogAuthorCountDto());
            }
        }
    }
}
