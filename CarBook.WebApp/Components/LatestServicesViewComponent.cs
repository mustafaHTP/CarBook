using CarBook.Application.Dtos.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class LatestServicesViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LatestServicesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Services/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var services = await response.Content.ReadAsAsync<List<GetServicesDto>>();

                return View(services);
            }

            return View();
        }
    }
}
