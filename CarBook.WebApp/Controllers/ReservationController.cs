using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.LocationDtos;
using CarBook.Application.Dtos.ReservationDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Models.ReservationModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace CarBook.WebApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IApiService _apiService;

        public ReservationController(IApiService apiService)
        {
            _apiService = apiService;
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

            var response = await _apiService.PostAsync("https://localhost:7116/api/Reservations", stringContent);

            if (response.IsSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LocationList = await GetLocationListAsync();
            ViewBag.CarList = await GetCarListAsync();

            return View(viewModel);
        }

        private async Task<IEnumerable<SelectListItem>?> GetLocationListAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetLocationsDto>>("https://localhost:7116/api/Locations");

            IEnumerable<SelectListItem>? locationList = null;
            if (response.IsSuccessful)
            {
                locationList = response.Result?.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name
                }).ToList();
            }

            return locationList;
        }

        private async Task<IEnumerable<SelectListItem>?> GetCarListAsync()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");

            IEnumerable<SelectListItem>? carList = null;
            if (response.IsSuccessful)
            {
                carList = response.Result?.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.BrandName} {c.ModelName}"
                }).ToList();
            }

            return carList;
        }
    }
}
