using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.FeatureDtos;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Brands?IncludeModels=false");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetBrandsDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBrandDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Brands", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createBrandDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Brands/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBrandByIdDto>(jsonData);

                var updateBrandViewModel = new UpdateBrandViewModel()
                {
                    Id = result.Id,
                    Name = result.Name
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7116/api/Brands", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBrandViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Brands/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
