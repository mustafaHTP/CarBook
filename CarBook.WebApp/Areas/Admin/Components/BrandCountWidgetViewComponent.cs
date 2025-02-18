using CarBook.Application.Dtos.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class BrandCountWidgetViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandCountWidgetViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Statistics/brand/count");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBrandCountDto>(content);

                return View(result);
            }
            else
            {
                return View(new GetBrandCountDto());
            }
        }
    }
}
