using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public FooterViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.FooterAddress = await GetFooterAddressAsync();

            return View();
        }

        private async Task<GetFooterAddressesDto?> GetFooterAddressAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetFooterAddressesDto>>("https://localhost:7116/api/FooterAddresses");
            GetFooterAddressesDto? getFooterAddressDto = null;
            if (response.IsSuccessful)
            {
                getFooterAddressDto = response.Result?.First();
            }

            return getFooterAddressDto;
        }
    }
}
