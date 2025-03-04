using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarFeatureDtos;
using CarBook.Application.Dtos.FeatureDtos;
using CarBook.WebApp.Areas.Admin.Models.FeatureModels;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Features");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetFeaturesDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createFeatureDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Features", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createFeatureDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Features/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetFeatureByIdDto>(jsonData);

                var updateFeatureViewModel = new UpdateFeatureViewModel()
                {
                    Id = result.Id,
                    Name = result.Name
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7116/api/Features", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateFeatureViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Features/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetCarFeaturesByCarId(int carId)
        {
            GetCarFeaturesViewModel getCarFeaturesViewModel = new();

            var client = _httpClientFactory.CreateClient();
            var carFeaturesResponse = await client.GetAsync($"https://localhost:7116/api/Cars/{carId}/CarFeatures");
            if (carFeaturesResponse.IsSuccessStatusCode)
            {
                var jsonData = await carFeaturesResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetCarFeaturesByCarIdDto>>(jsonData);

                getCarFeaturesViewModel.CarFeatures = result ?? [];
            }

            var carResponse = await client.GetAsync($"https://localhost:7116/api/Cars/{carId}");
            if (carResponse.IsSuccessStatusCode)
            {
                var jsonData = await carResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetCarByIdDto>(jsonData);

                getCarFeaturesViewModel.GetCarByIdDto = result;
            }

            return View(getCarFeaturesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvailability([FromForm] int carId, [FromForm] UpdateCarFeatureAvailabilityViewModel updateCarFeatureAvailabilityViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var updateCarFeatureDto = new UpdateCarFeatureDto
            {
                IsAvailable = updateCarFeatureAvailabilityViewModel.IsAvailable
            };

            var stringContent = new StringContent(
                JsonConvert.SerializeObject(updateCarFeatureDto),
                Encoding.UTF8,
                "application/json");
            var response = await client.PutAsync(
                $"https://localhost:7116/api/CarFeatures/{updateCarFeatureAvailabilityViewModel.CarFeatureId}",
                stringContent);

            return RedirectToAction(nameof(GetCarFeaturesByCarId), new { carId });
        }
    }
}
