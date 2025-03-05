using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarFeatureSummaryViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarFeatureSummaryViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var response = await _apiService.GetAsync<IEnumerable<GetCarFeaturesByCarIdDto>>($"https://localhost:7116/api/Cars/{carId}/CarFeatures");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
