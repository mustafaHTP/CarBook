using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.Application.Interfaces.Services;
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
        private readonly IApiService _apiService;

        public FooterAddressController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetFooterAddressesDto>>("https://localhost:7116/api/FooterAddresses");
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
        public async Task<IActionResult> Create(CreateFooterAddressViewModel createFooterAddressViewModel)
        {
            var createFooterAddressDto = new CreateFooterAddressDto
            {
                Description = createFooterAddressViewModel.Description,
                Address = createFooterAddressViewModel.Address,
                Email = createFooterAddressViewModel.Email,
                Phone = createFooterAddressViewModel.Phone
            };

            var json = JsonConvert.SerializeObject(createFooterAddressDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/FooterAddresses", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createFooterAddressDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetFooterAddressByIdDto>($"https://localhost:7116/api/FooterAddresses/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                var updateFooterAddressViewModel = new UpdateFooterAddressViewModel()
                {
                    Id = response.Result.Id,
                    Description = response.Result.Description,
                    Address = response.Result.Address,
                    Email = response.Result.Email,
                    Phone = response.Result.Phone
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

            var jsonData = JsonConvert.SerializeObject(updateFooterAddressDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PutAsync($"https://localhost:7116/api/FooterAddresses/{updateFooterAddressViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(updateFooterAddressViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _apiService.DeleteAsync($"https://localhost:7116/api/FooterAddresses/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
