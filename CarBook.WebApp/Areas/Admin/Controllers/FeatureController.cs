using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarFeatureDtos;
using CarBook.Application.Dtos.FeatureDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.FeatureModels;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IApiService _apiService;

        public FeatureController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetFeaturesDto>>("https://localhost:7116/api/Features");
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
        public async Task<IActionResult> Create(CreateFeatureModel createFeatureModel)
        {
            var createFeatureDto = new CreateFeatureDto
            {
                Name = createFeatureModel.Name
            };

            var json = JsonConvert.SerializeObject(createFeatureDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Features", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }

            return View(createFeatureDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetFeatureByIdDto>($"https://localhost:7116/api/Features/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateFeatureViewModel = new UpdateFeatureViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name
                };

                return View(updateFeatureViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureViewModel updateFeatureViewModel)
        {
            UpdateFeatureDto updateCarDto = new()
            {
                Id = updateFeatureViewModel.Id,
                Name = updateFeatureViewModel.Name
            };

            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync("https://localhost:7116/api/Features", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateFeatureViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Features/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetCarFeaturesByCarId(int carId)
        {
            GetCarFeaturesViewModel getCarFeaturesViewModel = new();

            var carFeaturesResponse = await _apiService.GetAsync<IEnumerable<GetCarFeaturesByCarIdDto>>($"https://localhost:7116/api/Cars/{carId}/CarFeatures");
            if (carFeaturesResponse.IsSuccessful)
            {
                getCarFeaturesViewModel.CarFeatures = carFeaturesResponse.Result ?? [];
            }

            var carResponse = await _apiService.GetAsync<GetCarByIdDto>($"https://localhost:7116/api/Cars/{carId}");
            if (carResponse.IsSuccessful)
            {
                getCarFeaturesViewModel.GetCarByIdDto = carResponse.Result;
            }

            return View(getCarFeaturesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvailability([FromForm] int carId, [FromForm] UpdateCarFeatureAvailabilityViewModel updateCarFeatureAvailabilityViewModel)
        {
            var updateCarFeatureDto = new UpdateCarFeatureDto
            {
                IsAvailable = updateCarFeatureAvailabilityViewModel.IsAvailable
            };

            var stringContent = new StringContent(
                JsonConvert.SerializeObject(updateCarFeatureDto),
                Encoding.UTF8,
                "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/CarFeatures/{updateCarFeatureAvailabilityViewModel.CarFeatureId}", stringContent);

            return RedirectToAction(nameof(GetCarFeaturesByCarId), new { carId });
        }
    }
}
