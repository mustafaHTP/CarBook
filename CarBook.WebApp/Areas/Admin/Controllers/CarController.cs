using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.ModelDtos;
using CarBook.Domain.Enums;
using CarBook.WebApp.Areas.Admin.Models.CarModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Cars/GetAllWithBrand");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetCarsWithBrandDto>>(jsonData);

                return View(result);
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

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Cars", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            // Get the car by id
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7116/api/Cars/{id}?IncludeModel=false&IncludeBrand=false");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Models = await GetModelList();
                ViewBag.TransmissionTypes = GetTransmissionTypeList();
                ViewBag.FuelTypes = GetFuelTypeList();

                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetCarByIdDto>(jsonData);

                var updateCarViewModel = new UpdateCarViewModel()
                {
                    Id = result.Id,
                    ModelId = result.ModelId,
                    Km = result.Km,
                    SeatCount = result.SeatCount,
                    Luggage = result.Luggage,
                    TransmissionType = result.TransmissionType,
                    FuelType = result.FuelType,
                    CoverImageUrl = result.CoverImageUrl,
                    BigImageUrl = result.BigImageUrl
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
                Id = updateCarViewModel.Id,
                ModelId = updateCarViewModel.ModelId,
                Km = updateCarViewModel.Km,
                SeatCount = updateCarViewModel.SeatCount,
                Luggage = updateCarViewModel.Luggage,
                TransmissionType = updateCarViewModel.TransmissionType,
                FuelType = updateCarViewModel.FuelType,
                CoverImageUrl = updateCarViewModel.CoverImageUrl,
                BigImageUrl = updateCarViewModel.BigImageUrl
            };

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7116/api/Cars", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            // If the update fails, return the view with the model
            // Get the car by id
            response = await client.GetAsync($"https://localhost:7116/api/Cars/{updateCarViewModel.Id}?IncludeModel=false&IncludeBrand=false");

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Models = await GetModelList();
                ViewBag.TransmissionTypes = GetTransmissionTypeList();
                ViewBag.FuelTypes = GetFuelTypeList();

                jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetCarByIdDto>(jsonData);

                updateCarViewModel = new UpdateCarViewModel()
                {
                    Id = result.Id,
                    ModelId = result.ModelId,
                    Km = result.Km,
                    SeatCount = result.SeatCount,
                    Luggage = result.Luggage,
                    TransmissionType = result.TransmissionType,
                    FuelType = result.FuelType,
                    CoverImageUrl = result.CoverImageUrl,
                    BigImageUrl = result.BigImageUrl
                };

                return View(updateCarViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Cars/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<SelectListItem>?> GetModelList()
        {
            var client = _httpClientFactory.CreateClient();
            var url = "https://localhost:7116/api/Models";
            var queryParams = "IncludeBrand=true&IncludeCars=true";
            var response = await client.GetAsync($"{url}?{queryParams}");

            IEnumerable<SelectListItem>? modelsSelectList = null;
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetModelsDto>>(jsonData);

                // Create a SelectList from the models
                modelsSelectList = result?.Select(m => new SelectListItem()
                {
                    Text = $"{m.Brand?.Name} {m.Name}",
                    Value = m.Id.ToString(),
                });
            }

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
