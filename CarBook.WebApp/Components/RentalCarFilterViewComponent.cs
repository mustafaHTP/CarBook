using CarBook.Application.Dtos.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook.WebApp.Components
{
    public class RentalCarFilterViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentalCarFilterViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Locations");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetLocationsDto>>(jsonData);

                var locationsSelectList = result?.Select(l => new SelectListItem()
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
