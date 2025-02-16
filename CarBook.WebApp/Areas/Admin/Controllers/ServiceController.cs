using CarBook.Application.Dtos.ServiceDtos;
using CarBook.WebApp.Areas.Admin.Models.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Services");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetServicesDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createServiceDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Services", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createServiceDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Services/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetServiceByIdDto>(jsonData);

                var updateServiceViewModel = new UpdateServiceViewModel()
                {
                    Description = result.Description,
                    IconUrl = result.IconUrl,
                    Title = result.Title,
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/Services/{updateServiceViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateServiceViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Services/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
