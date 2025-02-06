using CarBook.Application.Dtos.CarReservationPricingDtos;
using CarBook.Application.Features.CarReservationPricingFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet()]
        public async Task<IActionResult> GetAllWithCarAndPricingPlan()
        {
            var carReservationPricings = await _mediator.Send(new GetCarReservationPricingsQuery());

            return Ok(carReservationPricings);
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
