using CarBook.Application.Dtos.About;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Abouts/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var abouts = await response.Content.ReadFromJsonAsync<List<GetAboutDto>>();

                return View(abouts);
            }

            return View();
        }
    }
}
