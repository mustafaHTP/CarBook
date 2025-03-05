using CarBook.Application.Dtos.ServiceDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IApiService _apiService;

        public ServiceController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetServicesDto>>("https://localhost:7116/api/Services");
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
        public async Task<IActionResult> Create(CreateServiceViewModel createServiceViewModel)
        {
            var createServiceDto = new CreateServiceDto
            {
                Description = createServiceViewModel.Description,
                IconUrl = createServiceViewModel.IconUrl,
                Title = createServiceViewModel.Title
            };

            var json = JsonConvert.SerializeObject(createServiceDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Services", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createServiceDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetServiceByIdDto>($"https://localhost:7116/api/Services/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateServiceViewModel = new UpdateServiceViewModel()
                {
                    Description = response.Result.Description,
                    IconUrl = response.Result.IconUrl,
                    Title = response.Result.Title,
                };

                return View(updateServiceViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceViewModel updateServiceViewModel)
        {
            UpdateServiceDto updateServiceDto = new()
            {
                Description = updateServiceViewModel.Description,
                IconUrl = updateServiceViewModel.IconUrl,
                Title = updateServiceViewModel.Title
            };

            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Services/{updateServiceViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateServiceViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Services/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
