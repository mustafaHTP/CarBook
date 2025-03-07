using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.ModelDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.Domain.Enums;
using CarBook.WebApp.Areas.Admin.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IApiService _apiService;

        public CarController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var response =
                await _apiService.GetAsync<IEnumerable<GetCarsDto>>("https://localhost:7116/api/Cars");
            if (response.IsSuccessful)
            {
                return View(response.Result);
            }

            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Models = await GetModelList();
            ViewBag.TransmissionTypes = GetTransmissionTypeList();
            ViewBag.FuelTypes = GetFuelTypeList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel createCarViewModel)
        {
            CreateCarDto createCarDto = new()
            {
                ModelId = createCarViewModel.ModelId,
                Km = createCarViewModel.Km,
                SeatCount = createCarViewModel.SeatCount,
                Luggage = createCarViewModel.Luggage,
                TransmissionType = createCarViewModel.TransmissionType,
                FuelType = createCarViewModel.FuelType,
                CoverImageUrl = createCarViewModel.CoverImageUrl,
                BigImageUrl = createCarViewModel.BigImageUrl
            };

            var jsonData = JsonConvert.SerializeObject(createCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _apiService.PostAsync("https://localhost:7116/api/Cars", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _apiService.GetAsync<GetCarByIdDto>($"https://localhost:7116/api/Cars/{id}");
            if (response.IsSuccessful && response.Result is not null)
            {
                ViewBag.Models = await GetModelList();
                ViewBag.TransmissionTypes = GetTransmissionTypeList();
                ViewBag.FuelTypes = GetFuelTypeList();

                var updateCarViewModel = new UpdateCarViewModel()
                {
                    Id = response.Result.Id,
                    ModelId = response.Result.ModelId,
                    Km = response.Result.Km,
                    SeatCount = response.Result.SeatCount,
                    Luggage = response.Result.Luggage,
                    TransmissionType = response.Result.TransmissionType,
                    FuelType = response.Result.FuelType,
                    CoverImageUrl = response.Result.CoverImageUrl,
                    BigImageUrl = response.Result.BigImageUrl
                };

                return View(updateCarViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarViewModel updateCarViewModel)
        {
            UpdateCarDto updateCarDto = new()
            {
                ModelId = updateCarViewModel.ModelId,
                Km = updateCarViewModel.Km,
                SeatCount = updateCarViewModel.SeatCount,
                Luggage = updateCarViewModel.Luggage,
                TransmissionType = updateCarViewModel.TransmissionType,
                FuelType = updateCarViewModel.FuelType,
                CoverImageUrl = updateCarViewModel.CoverImageUrl,
                BigImageUrl = updateCarViewModel.BigImageUrl
            };

            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response =
                await _apiService.PutAsync($"https://localhost:7116/api/Cars/{updateCarViewModel.Id}", content);
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Models = await GetModelList();
                ViewBag.TransmissionTypes = GetTransmissionTypeList();
                ViewBag.FuelTypes = GetFuelTypeList();

                return View(updateCarViewModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiService.DeleteAsync($"https://localhost:7116/api/Cars/{id}");
            if (response.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetModelList()
        {
            var response = await _apiService.GetAsync<IEnumerable<GetModelsDto>>("https://localhost:7116/api/Models");

            IEnumerable<SelectListItem>? modelsSelectList = null;
            modelsSelectList = response.Result?.Select(m => new SelectListItem()
            {
                Text = $"{m.BrandName} {m.Name}",
                Value = m.Id.ToString(),
            });

            return await Task.FromResult(modelsSelectList);
        }

        private static IEnumerable<SelectListItem> GetTransmissionTypeList()
        {
            return Enum.GetValues(typeof(TransmissionType)).Cast<TransmissionType>().Select(t => new SelectListItem()
            {
                Text = t.ToString(),
                Value = ((int)t).ToString()
            });
        }

        private static IEnumerable<SelectListItem> GetFuelTypeList()
        {
            return Enum.GetValues(typeof(FuelType)).Cast<FuelType>().Select(f => new SelectListItem()
            {
                Text = f.ToString(),
                Value = ((int)f).ToString()
            });
        }
    }
}
