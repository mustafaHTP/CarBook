using CarBook.Application.Dtos.AboutDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.AboutModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IApiService _apiService;

        public AboutController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetAboutsDto>>("https://localhost:7116/api/Abouts");
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
        public async Task<IActionResult> Create(CreateAboutViewModel createAboutViewModel)
        {
            var createAboutDto = new CreateAboutDto
            {
                Title = createAboutViewModel.Title,
                Description = createAboutViewModel.Description,
                ImageUrl = createAboutViewModel.ImageUrl
            };

            var json = JsonConvert.SerializeObject(createAboutDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Abouts", stringContent);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createAboutDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetAboutByIdDto>($"https://localhost:7116/api/Abouts/{id}");

            if (response.IsSuccessful && response.Result is not null)
            {
                var updateAboutViewModel = new UpdateAboutViewModel()
                {
                    Id = response.Result.Id,
                    Title = response.Result.Title,
                    Description = response.Result.Description,
                    ImageUrl = response.Result.ImageUrl
                };

                return View(updateAboutViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutViewModel updateAboutViewModel)
        {
            UpdateAboutDto updateAboutDto = new()
            {
                Title = updateAboutViewModel.Title,
                Description = updateAboutViewModel.Description,
                ImageUrl = updateAboutViewModel.ImageUrl
            };

            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Abouts/{updateAboutViewModel.Id}", content);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateAboutViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Abouts/{id}");

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
