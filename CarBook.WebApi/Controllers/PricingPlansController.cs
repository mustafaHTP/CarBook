using CarBook.Application.Dtos.PricingPlanDtos;
using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Features.PricingPlanFeatures.Queries;
using MediatR;
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
            var pricingPlanDtos = pricingPlans.Select(pricingPlan => new GetPricingPlansDto
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            });

            return Ok(pricingPlanDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pricingPlan = await _mediator.Send(new GetPricingPlanByIdQuery() { Id = id });
            var pricingPlanDto = new GetPricingPlanByIdDto
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            };

            return Ok(pricingPlanDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingPlanDto createPricingPlanDto)
        {
            var command = new CreatePricingPlanCommand
            {
                Name = createPricingPlanDto.Name
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePricingPlanDto updatePricingPlanDto)
        {
            var command = new UpdatePricingPlanCommand
            {
                Id = id,
                Name = updatePricingPlanDto.Name
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePricingPlanCommand
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been deleted");
        }
    }
}
