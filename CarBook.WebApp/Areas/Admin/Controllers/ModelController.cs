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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiService _apiService;

        public ModelController(IHttpClientFactory httpClientFactory, IApiService apiService)
        {
            _httpClientFactory = httpClientFactory;
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _apiService.GetAsync<IEnumerable<GetModelsDto>>("https://localhost:7116/api/Models");

            return View(models);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createModelDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Models", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createModelDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Models/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetModelByIdDto>(jsonData);

                var updateModelViewModel = new UpdateModelViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    BrandId = result.BrandId
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateModelDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Models/{updateModelViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateModelViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Models/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetBrandList()
        {
            var url = "https://localhost:7116/api/Brands";
            var models = await _apiService.GetAsync<IEnumerable<GetBrandsDto>>(url);

            IEnumerable<SelectListItem>? brandSelectList = null;

            // Create a SelectList from the models
            brandSelectList = models?.Select(m => new SelectListItem()
            {
                Text = $"{m.Name}",
                Value = m.Id.ToString(),
            });

            return await Task.FromResult(brandSelectList);
        }
    }
}
