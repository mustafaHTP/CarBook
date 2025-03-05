using CarBook.Application.Dtos.AboutDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public AboutViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetAboutsDto>>("https://localhost:7116/api/Abouts");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }
    }
}
