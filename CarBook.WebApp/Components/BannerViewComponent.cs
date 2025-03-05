using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public BannerViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetBannersDto>>("https://localhost:7116/api/Banners");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
