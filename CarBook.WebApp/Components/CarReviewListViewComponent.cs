﻿using CarBook.Application.Dtos.CarReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class CarReviewListViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarReviewListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int carId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = 
                await client.GetAsync($"https://localhost:7116/api/Cars/{carId}/CarReviews");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<GetCarReviewByCarIdDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
