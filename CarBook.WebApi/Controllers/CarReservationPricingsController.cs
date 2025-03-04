using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Application.Features.CarReservationPricingFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReservationPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarReservationPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCarReservationPricingsQueryDto queryDto)
        {
            var query = new GetCarReservationPricingsQuery()
            {
                RentalPeriods = queryDto.RentalPeriods
            };
            var carReservationPricings = await _mediator.Send(query);
            var carReservationPricingsDto = carReservationPricings.Select(crp => new GetCarReservationPricingsDto()
            {
                Id = crp.Id,
                CarId = crp.CarId,
                BrandId = crp.Car.Model.BrandId,
                BrandName = crp.Car.Model.Brand.Name,
                ModelId = crp.Car.ModelId,
                ModelName = crp.Car.Model.Name,
                CoverImageUrl = crp.Car.CoverImageUrl,
                BigImageUrl = crp.Car.BigImageUrl,
                Km = crp.Car.Km,
                SeatCount = crp.Car.SeatCount,
                Luggage = crp.Car.Luggage,
                TransmissionType = crp.Car.TransmissionType,
                FuelType = crp.Car.FuelType,
                PricingPlanId = crp.PricingPlanId,
                PricingPlanName = crp.PricingPlan.Name,
                Price = crp.Price
            });

            return Ok(carReservationPricingsDto);
        }

        [HttpGet("GetAllWithDayPricingPlan")]
        public async Task<IActionResult> GetAllWithDayPricingPlan()
        {
            var carReservationPricings = await _mediator.Send(new GetCarReservationPricingsWithDayPricingPlanQuery());

            var carReservationPricingsDto = carReservationPricings.Select(crp => new GetCarReservationPricingsWithDayPricingPlanDto()
            {
                Id = crp.Id,
                CarId = crp.CarId,
                Car = crp.Car,
                PricingPlanId = crp.PricingPlanId,
                PricingPlan = crp.PricingPlan,
                Price = crp.Price
            });

            return Ok(carReservationPricingsDto);
        }
    }
}
