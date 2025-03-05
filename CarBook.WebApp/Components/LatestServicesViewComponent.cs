using CarBook.Application.Dtos.ServiceDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApp.Components
{
    public class LatestServicesViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public LatestServicesViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetServicesDto>>("https://localhost:7116/api/Services");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
