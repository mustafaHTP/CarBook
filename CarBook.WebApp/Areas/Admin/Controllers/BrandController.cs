using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.FeatureDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BrandModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IApiService _apiService;

        public BrandController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBrandsDto>>("https://localhost:7116/api/Brands?IncludeModels=false");
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
        public async Task<IActionResult> Create(CreateBrandViewModel createBrandViewModel)
        {
            var createBrandDto = new CreateBrandDto
            {
                Name = createBrandViewModel.Name
            };

            var json = JsonConvert.SerializeObject(createBrandDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Brands", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }

            return View(createBrandDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBrandByIdDto>($"https://localhost:7116/api/Brands/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateBrandViewModel = new UpdateBrandViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name
                };

                return View(updateBrandViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandViewModel updateBrandViewModel)
        {
            UpdateFeatureDto updateBrandDto = new()
            {
                Id = updateBrandViewModel.Id,
                Name = updateBrandViewModel.Name
            };

            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync("https://localhost:7116/api/Brands", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBrandViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Brands/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
