using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class FooterAddressViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public FooterAddressViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetFooterAddressesDto>>("https://localhost:7116/api/FooterAddresses");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
