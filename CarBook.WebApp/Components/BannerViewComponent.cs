﻿using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.FooterAddressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Banners");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBannersDto>>(jsonData);

                return View(values);
            }

            return View();
        }
    }
}
