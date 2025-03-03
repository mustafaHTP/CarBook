using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.Application.Dtos.ServiceDtos;
using CarBook.Application.Dtos.SocialMediaDtos;
using CarBook.WebApp.Areas.Admin.Models.FooterAddressModels;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/SocialMedias");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetSocialMediasDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createSocialMediaDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/SocialMedias", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createSocialMediaDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/SocialMedias/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetSocialMediaByIdDto>(jsonData);

                var updateSocialMediaViewModel = new UpdateSocialMediaViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Url = result.Url,
                    Icon = result.Icon
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/SocialMedias/{updateSocialMediaViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateSocialMediaViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/SocialMedias/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
