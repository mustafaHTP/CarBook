using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Areas.Admin.Models.BannerModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IApiService _apiService;

        public BannerController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetBannersDto>>("https://localhost:7116/api/Banners");

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
        public async Task<IActionResult> Create(CreateBannerViewModel createBannerViewModel)
        {
            var createBannerDto = new CreateBannerDto
            {
                Title = createBannerViewModel.Title,
                Description = createBannerViewModel.Description,
                VideoDescription = createBannerViewModel.VideoDescription,
                VideoUrl = createBannerViewModel.VideoUrl
            };

            var json = JsonConvert.SerializeObject(createBannerDto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _apiService.PostAsync("https://localhost:7116/api/Banners", stringContent);

            if (response.IsSuccessful)
            {
                return RedirectToAction("Index");
            }

            return View(createBannerDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetBannerByIdDto>($"https://localhost:7116/api/Banners/{id}");

            if (response.IsSuccessful && response.Result is not null)
            {
                var updateBannerViewModel = new UpdateBannerViewModel()
                {
                    Id = response.Result.Id,
                    Title = response.Result.Title,
                    Description = response.Result.Description,
                    VideoDescription = response.Result.VideoDescription,
                    VideoUrl = response.Result.VideoUrl
                };

                return View(updateBannerViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBannerViewModel updateBannerViewModel)
        {
            UpdateBannerDto updateBannerDto = new()
            {
                Title = updateBannerViewModel.Title,
                Description = updateBannerViewModel.Description,
                VideoDescription = updateBannerViewModel.VideoDescription,
                VideoUrl = updateBannerViewModel.VideoUrl
            };

            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/Banners/{updateBannerViewModel.Id}", content);

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBannerViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Banners/{id}");

            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
