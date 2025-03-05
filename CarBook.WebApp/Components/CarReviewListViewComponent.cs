using CarBook.Application.Dtos.CarReviewDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarReviewListViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarReviewListViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetCarReviewByCarIdDto>>($"https://localhost:7116/api/Cars/{carId}/CarReviews");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
