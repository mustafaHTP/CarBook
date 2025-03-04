using CarBook.Application.Dtos.AboutDtos;
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
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var claims = HttpContext.User.Claims.ToList();
            var token = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value?.ToString();

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync($"https://localhost:7116/api/Abouts");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAboutsDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createAboutDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Abouts", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createAboutDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Abouts/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetAboutByIdDto>(jsonData);

                var updateAboutViewModel = new UpdateAboutViewModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    Description = result.Description,
                    ImageUrl = result.ImageUrl
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Abouts/{updateAboutViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateAboutViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Abouts/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
