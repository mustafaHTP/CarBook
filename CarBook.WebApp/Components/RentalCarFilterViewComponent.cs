using CarBook.Application.Dtos.LocationDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class RentalCarFilterViewComponent : ViewComponent
    {
        private readonly IApiService _apiService;

        public RentalCarFilterViewComponent(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetLocationsDto>>("https://localhost:7116/api/Locations");
            if (response.IsSuccessful && response.Result is not null)
            {
                var locationsSelectList = response.Result?.Select(l => new SelectListItem()
                {
                    Text = l.Name,
                    Value = l.Id.ToString(),
                });

                ViewBag.LocationList = locationsSelectList;

                return View();
            }

            return View();
        }
    }
}
