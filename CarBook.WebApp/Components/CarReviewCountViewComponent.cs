using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarReviewCountViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public CarReviewCountViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> InvokeAsync(int carId)
        {
            var response =
                await _apiService.GetAsync<GetCarReviewsCountByCarIdDto>($"https://localhost:7116/api/Statistics/car/{carId}/carReviews/count");
            int carReviewCount = 0;
            if (response.IsSuccessful)
            {
                carReviewCount = response.Result?.CarReviewCount ?? 0;
            }

            return carReviewCount.ToString();
        }
    }
}
