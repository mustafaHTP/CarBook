using CarBook.Application.Dtos.SocialMediaDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.SocialMediaModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IApiService _apiService;

        public SocialMediaController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetSocialMediasDto>>("https://localhost:7116/api/SocialMedias");
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
        public async Task<IActionResult> Create(CreateSocialMediaViewModel createSocialMediaViewModel)
        {
            var createSocialMediaDto = new CreateSocialMediaDto
            {
                Name = createSocialMediaViewModel.Name,
                Url = createSocialMediaViewModel.Url,
                Icon = createSocialMediaViewModel.Icon
            };

            var json = JsonConvert.SerializeObject(createSocialMediaDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/SocialMedias", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createSocialMediaDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetSocialMediaByIdDto>($"https://localhost:7116/api/SocialMedias/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateSocialMediaViewModel = new UpdateSocialMediaViewModel()
                {
                    Id = response.Result.Id,
                    Name = response.Result.Name,
                    Url = response.Result.Url,
                    Icon = response.Result.Icon
                };

                return View(updateSocialMediaViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaViewModel updateSocialMediaViewModel)
        {
            UpdateSocialMediaDto updateSocialMediaDto = new()
            {
                Name = updateSocialMediaViewModel.Name,
                Url = updateSocialMediaViewModel.Url,
                Icon = updateSocialMediaViewModel.Icon
            };

            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/SocialMedias/{updateSocialMediaViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateSocialMediaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/SocialMedias/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
