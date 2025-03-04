using CarBook.Application.Dtos.PricingPlanDtos;
using CarBook.WebApp.Areas.Admin.Models.PricingPlanModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PricingPlanController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingPlanController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/PricingPlans");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetPricingPlansDto>>(jsonData);

                return View(result);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingPlanViewModel createPricingPlanViewModel)
        {
            var createPricingPlanDto = new CreatePricingPlanDto
            {
                Name = createPricingPlanViewModel.Name
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createPricingPlanDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/PricingPlans", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createPricingPlanDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/PricingPlans/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetPricingPlanByIdDto>(jsonData);

                var updatePricingPlanViewModel = new UpdatePricingPlanViewModel()
                {
                    Id = result.Id,
                    Name = result.Name
                };

                return View(updatePricingPlanViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingPlanViewModel updatePricingPlanViewModel)
        {
            UpdatePricingPlanDto updatePricingPlanDto = new()
            {
                Name = updatePricingPlanViewModel.Name
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricingPlanDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/PricingPlans/{updatePricingPlanViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updatePricingPlanViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/PricingPlans/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
