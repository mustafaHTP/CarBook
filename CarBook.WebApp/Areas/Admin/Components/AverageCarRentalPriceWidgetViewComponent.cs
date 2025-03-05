﻿using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Areas.Admin.Components
{
    public class AverageCarRentalPriceWidgetViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public AverageCarRentalPriceWidgetViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(params string[] rentalPeriods)
        {
            string query = string.Empty;
            if (rentalPeriods != null && rentalPeriods.Length != 0)
            {
                query = string.Join(',', rentalPeriods);
            }

            var apiEndpoint = "https://localhost:7116/api/Statistics/carRentalPrice/avg";
            var url = string.IsNullOrEmpty(query)
                ? apiEndpoint
                : $"{apiEndpoint}?rentalPeriods={query}";

            var response = await _apiService.GetAsync<GetAverageCarRentalPriceDto>(url);
            if (response.IsSuccessful)
            {
                ViewBag.RentalPeriods = query;

                return View(response.Result);
            }
            else
            {
                return View(new GetAverageCarRentalPriceDto());
            }
        }
    }
}
