﻿using CarBook.Application.Dtos.About;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Abouts/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAboutsDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
