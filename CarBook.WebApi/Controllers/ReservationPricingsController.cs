using CarBook.Application.Features.ReservationPricingFeatures.Commands;
using CarBook.Application.Features.ReservationPricingFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservationPricings = await _mediator.Send(new GetReservationPricingsQuery());

            return Ok(reservationPricings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservationPricing = await _mediator.Send(new GetReservationPricingByIdQuery() { Id = id });

            return Ok(reservationPricing);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReservationPricingCommand createReservationPricingCommand)
        {
            await _mediator.Send(createReservationPricingCommand);

            return Ok("Reservation Pricing has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateReservationPricingCommand updateReservationPricingCommand)
        {
            await _mediator.Send(updateReservationPricingCommand);

            return Ok("Reservation Pricing has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteReservationPricingCommand deleteReservationPricingCommand)
        {
            await _mediator.Send(deleteReservationPricingCommand);

            return Ok("Reservation Pricing has been deleted");
        }
    }
}
