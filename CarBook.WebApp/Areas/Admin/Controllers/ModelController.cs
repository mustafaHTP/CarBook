using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.ModelDtos;
using CarBook.Application.Dtos.PricingPlanDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.ModelModels;
using CarBook.WebApp.Areas.Admin.Models.PricingPlanModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        private readonly IApiService _apiService;

        public ModelController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetModelsDto>>("https://localhost:7116/api/Models");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BrandList = await GetBrandList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelViewModel createModelViewModel)
        {
            var createModelDto = new CreateModelDto
            {
                Name = createModelViewModel.Name,
                BrandId = createModelViewModel.BrandId
            };

            var json = JsonConvert.SerializeObject(createModelDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Models", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createModelDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetModelByIdDto>($"https://localhost:7116/api/Models/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateModelViewModel = new UpdateModelViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                    BrandId = response.Result.BrandId
                };

                ViewBag.BrandList = await GetBrandList();

                return View(updateModelViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateModelViewModel updateModelViewModel)
        {
            UpdateModelDto updateModelDto = new()
            {
                BrandId = updateModelViewModel.BrandId,
                Name = updateModelViewModel.Name
            };

            var jsonData = JsonConvert.SerializeObject(updateModelDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Models/{updateModelViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateModelViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Models/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetBrandList()
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetBrandsDto>>("https://localhost:7116/api/Brands");
            IEnumerable<SelectListItem>? brandSelectList = null;
            brandSelectList = response.Result?.Select(m => new SelectListItem()
            {
                Text = $"{m.Name}",
                Value = m.Id.ToString(),
            });

            return await Task.FromResult(brandSelectList);
        }
    }
}
