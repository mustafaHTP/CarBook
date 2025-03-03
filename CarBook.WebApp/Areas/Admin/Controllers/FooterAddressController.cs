using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.WebApp.Areas.Admin.Models.FooterAddressModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAddressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/FooterAddresses");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<GetFooterAddressesDto>>(jsonData);

                return View(result);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressViewModel createFooterAddressViewModel)
        {
            var createFooterAddressDto = new CreateFooterAddressDto
            {
                Description = createFooterAddressViewModel.Description,
                Address = createFooterAddressViewModel.Address,
                Email = createFooterAddressViewModel.Email,
                Phone = createFooterAddressViewModel.Phone
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createFooterAddressDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/FooterAddresses", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createFooterAddressDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/FooterAddresses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetFooterAddressByIdDto>(jsonData);

                var updateFooterAddressViewModel = new UpdateFooterAddressViewModel()
                {
                    Id = result.Id,
                    Description = result.Description,
                    Address = result.Address,
                    Email = result.Email,
                    Phone = result.Phone
                };

                return View(updateFooterAddressViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateFooterAddressViewModel updateFooterAddressViewModel)
        {
            UpdateFooterAddressDto updateFooterAddressDto = new()
            {
                Description = updateFooterAddressViewModel.Description,
                Address = updateFooterAddressViewModel.Address,
                Email = updateFooterAddressViewModel.Email,
                Phone = updateFooterAddressViewModel.Phone
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7116/api/FooterAddresses/{updateFooterAddressViewModel.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateFooterAddressViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/FooterAddresses/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
