using CarBook.Application.Dtos.PricingPlanDtos;
using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalPeriodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalPeriodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pricingPlans = await _mediator.Send(new GetRentalPeriodsQuery());
            var pricingPlanDtos = pricingPlans.Select(pricingPlan => new GetRentalPeriodsDto
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            });

            return Ok(pricingPlanDtos);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<RentalPeriod>))]
        public async Task<IActionResult> GetById(int id)
        {
            var pricingPlan = await _mediator.Send(new GetRentalPeriodByIdQuery() { Id = id });
            var pricingPlanDto = new GetRentalPeriodByIdDto
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            };

            return Ok(pricingPlanDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRentalPeriodDto createPricingPlanDto)
        {
            var command = new CreateRentaPeriodCommand
            {
                Name = createPricingPlanDto.Name
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<RentalPeriod>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRentalPeriodDto updatePricingPlanDto)
        {
            var command = new UpdateRentaPeriodCommand
            {
                Id = id,
                Name = updatePricingPlanDto.Name
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<RentalPeriod>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRentalPeriodCommand
            {
                Id = id
            };
            await _mediator.Send(command);

            return Ok("Pricing Plan has been deleted");
        }
    }
}
