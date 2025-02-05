using CarBook.Application.Features.ReservationPricingFeatures.Commands;
using CarBook.Application.Features.ReservationPricingFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pricingPlans = await _mediator.Send(new GetPricingPlansQuery());

            return Ok(pricingPlans);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pricingPlan = await _mediator.Send(new GetPricingPlanByIdQuery() { Id = id });

            return Ok(pricingPlan);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingPlanCommand createReservationPricingCommand)
        {
            await _mediator.Send(createReservationPricingCommand);

            return Ok("Pricing Plan has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingPlanCommand updateReservationPricingCommand)
        {
            await _mediator.Send(updateReservationPricingCommand);

            return Ok("Pricing Plan has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePricingPlanCommand deleteReservationPricingCommand)
        {
            await _mediator.Send(deleteReservationPricingCommand);

            return Ok("Pricing Plan has been deleted");
        }
    }
}
