using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class BrandCountWidgetViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public BrandCountWidgetViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response =
                await _apiService.GetAsync<GetBrandCountDto>("https://localhost:7116/api/Statistics/brand/count");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }
            else
            {
                return View(new GetBrandCountDto());
            }
        }
    }
}
