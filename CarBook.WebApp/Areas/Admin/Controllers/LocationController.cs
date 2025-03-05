using CarBook.Application.Dtos.LocationDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.LocationModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class LocationController : Controller
    {
        private readonly IApiService _apiService;

        public LocationController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetLocationsDto>>("https://localhost:7116/api/Locations");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationViewModel createLocationViewModel)
        {
            var createLocationDto = new CreateLocationDto
            {
                Name = createLocationViewModel.Name
            };

            var json = JsonConvert.SerializeObject(createLocationDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response =
                await _apiService.PostAsync("https://localhost:7116/api/Locations", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createLocationDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetLocationByIdDto>($"https://localhost:7116/api/Locations/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateLocationViewModel = new UpdateLocationViewModel()
                {
                    Name = response.Result.Name
                };

                return View(updateLocationViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLocationViewModel updateLocationViewModel)
        {
            UpdateLocationDto updateLocationDto = new()
            {
                Name = updateLocationViewModel.Name
            };

            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Locations/{updateLocationViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateLocationViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _apiService.DeleteAsync($"https://localhost:7116/api/Locations/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
