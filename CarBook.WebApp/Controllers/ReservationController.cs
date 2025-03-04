using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.LocationDtos;
using CarBook.Application.Dtos.ReservationDtos;
using CarBook.WebApp.Models.ReservationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.LocationList = await GetLocationListAsync();
            ViewBag.CarList = await GetCarListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateReservationViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var reservationDto = new CreateReservationDto
            {
                CarId = viewModel.CarId,
                CustomerFirstName = viewModel.CustomerFirstName,
                CustomerLastName = viewModel.CustomerLastName,
                CustomerEmail = viewModel.CustomerEmail,
                PickUpLocationId = viewModel.PickUpLocationId,
                DropOffLocationId = viewModel.DropOffLocationId
            };

            var stringContent = new StringContent(
                JsonConvert.SerializeObject(reservationDto),
                Encoding.UTF8,
                "application/json");
            var response = await client.PostAsync(
                "https://localhost:7116/api/Reservations",
                stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LocationList = await GetLocationListAsync();
            ViewBag.CarList = await GetCarListAsync();

            return View(viewModel);
        }

        private async Task<IEnumerable<SelectListItem>?> GetLocationListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Locations");
            IEnumerable<SelectListItem>? locationList = null;
            if (response.IsSuccessStatusCode)
            {
                var locationsJson = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<GetLocationsDto>>(locationsJson);

                locationList = locations?.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                }).ToList();
            }

            return locationList;
        }

        private async Task<IEnumerable<SelectListItem>?> GetCarListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Cars");
            IEnumerable<SelectListItem>? carList = null;
            if (response.IsSuccessStatusCode)
            {
                var carsJson = await response.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<IEnumerable<GetCarsDto>>(carsJson);

                carList = cars?.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.BrandName} {c.ModelName}"
                }).ToList();
            }

            return carList;
        }
    }
}
