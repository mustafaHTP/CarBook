using CarBook.Application.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.FooterAddress = await GetFooterAddressAsync();

            return View();
        }

        private async Task<GetFooterAddressesDto?> GetFooterAddressAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/FooterAddresses");
            GetFooterAddressesDto? getFooterAddressDto = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var addresses = JsonConvert.DeserializeObject<IEnumerable<GetFooterAddressesDto>>(content);

                getFooterAddressDto = addresses?.First();
            }

            return getFooterAddressDto;
        }
    }
}
