using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Domain.Entities;
using CarBook.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebApp.Controllers
{
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/CarReservationPricings");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var carReservationPricings = JsonConvert.DeserializeObject<IEnumerable<GetCarReservationPricingsDto>>(content);

                var carReservationListViewModel = carReservationPricings?
                    .GroupBy(crp => crp.CarId)
                    .Select(carGroup => new GetCarReservationListViewModel()
                    {
                        Id = carGroup.First().CarId,
                        ModelId = carGroup.First().ModelId,
                        ModelName = carGroup.First().ModelName,
                        BrandId = carGroup.First().BrandId,
                        BrandName = carGroup.First().BrandName,
                        Km = carGroup.First().Km,
                        SeatCount = carGroup.First().SeatCount,
                        Luggage = carGroup.First().Luggage,
                        TransmissionType = carGroup.First().TransmissionType,
                        FuelType = carGroup.First().FuelType,
                        CoverImageUrl = carGroup.First().CoverImageUrl,
                        BigImageUrl = carGroup.First().BigImageUrl,
                        PricingPlans = carGroup.Select(crp => new PricingPlanViewModel()
                        {
                            PricingPlanId = crp.PricingPlanId,
                            PricingPlanName = crp.PricingPlanName,
                            Price = crp.Price
                        }).ToList()
                    });

                return View(carReservationListViewModel);
            }

            return View();
        }
    }
}
