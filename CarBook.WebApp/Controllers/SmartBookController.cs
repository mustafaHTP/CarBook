using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.SmartBookDtos;
using CarBook.Application.Interfaces.Services;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebApp.Controllers
{
    public class SmartBookController : Controller
    {
        private readonly ISmartBookService _smartBookService;
        private readonly IApiService _apiService;

        public SmartBookController(ISmartBookService smartBookService, IApiService apiService)
        {
            _smartBookService = smartBookService;
            _apiService = apiService;
        }

        public IActionResult Recommend()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recommend([FromForm] CreateCarRecommendationViewModel createCarRecommendationViewModel)
        {
            var smartBookRequestDto = new SmartBookRequestDto
            {
                UserInput = createCarRecommendationViewModel.UserInput
            };

            try
            {
                var smartBookResponseDto = await _smartBookService.GetResponseAsync(smartBookRequestDto);

                return RedirectToAction(nameof(Result), smartBookResponseDto);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return View();
            }
        }

        public async Task<IActionResult> Result(SmartBookResponseDto smartBookResponseDto)
        {
            var response = await _apiService.GetAsync<GetCarByIdDto>($"https://localhost:7116/api/Cars/{smartBookResponseDto.CarId}");

            if (!response.IsSuccessful)
            {
                return RedirectToAction(nameof(Recommend));
            }

            SmartBookRecommendationResultViewModel smartBookRecommendationResultViewModel = new()
            {
                Car = response.Result!,
                Reason = smartBookResponseDto.Reason ?? string.Empty
            };

            return View(smartBookRecommendationResultViewModel);
        }
    }
}
