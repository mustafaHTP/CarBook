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

            return Ok(carReservationPricings);
        }
    }
}
