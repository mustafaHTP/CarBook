using CarBook.Application.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class FooterAddressViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAddressViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/FooterAddresses");

            if (response.IsSuccessStatusCode)
            {
                var footerAddresses = await response.Content.ReadAsAsync<List<GetFooterAddressesDto>>();

                return View(footerAddresses);
            }

            return View();
        }
    }
}
