using CarBook.Application.Dtos.RentalPeriodDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.PricingPlanModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RentalPeriodController : Controller
    {
        private readonly IApiService _apiService;

        public RentalPeriodController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetRentalPeriodsDto>>("https://localhost:7116/api/RentalPeriods");
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
        public async Task<IActionResult> Create(CreatePricingPlanViewModel createPricingPlanViewModel)
        {
            var createPricingPlanDto = new CreateRentalPeriodDto
            {
                Name = createPricingPlanViewModel.Name
            };

            var json = JsonConvert.SerializeObject(createPricingPlanDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/RentalPeriods", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createPricingPlanDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response =
                await _apiService.GetAsync<GetRentalPeriodByIdDto>($"https://localhost:7116/api/RentalPeriods/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updatePricingPlanViewModel = new UpdatePricingPlanViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name
                };

                return View(updatePricingPlanViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePricingPlanViewModel updatePricingPlanViewModel)
        {
            UpdateRentalPeriodDto updatePricingPlanDto = new()
            {
                Name = updatePricingPlanViewModel.Name
            };

            var jsonData = JsonConvert.SerializeObject(updatePricingPlanDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/RentalPeriods/{updatePricingPlanViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updatePricingPlanViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/RentalPeriods/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
