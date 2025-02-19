using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.FeatureDtos;
using CarBook.WebApp.Areas.Admin.Models.BannerModels;
using CarBook.WebApp.Areas.Admin.Models.FeatureModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Banners");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetBannersDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBannerDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Banners", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createBannerDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Banners/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetBannerByIdDto>(jsonData);

                var updateBannerViewModel = new UpdateBannerViewModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    VideoDescription = result.VideoDescription,
                    VideoUrl = result.VideoUrl
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBannerDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Banners/{updateBannerViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateBannerViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Banners/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
