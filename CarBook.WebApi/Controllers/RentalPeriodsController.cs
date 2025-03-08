using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.RentalPeriodDtos;
using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
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
            var rentalPeriods = await _mediator.Send(new GetRentalPeriodsQuery());
            var rentalPeriodsDto = rentalPeriods.Select(pricingPlan => new GetRentalPeriodsDto
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            });

            return Ok(GenericApiResponse<IEnumerable<GetRentalPeriodsDto>>.Success(rentalPeriodsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<RentalPeriod>))]
        public async Task<IActionResult> GetById(int id)
        {
            var rentalPeriod = await _mediator.Send(new GetRentalPeriodByIdQuery() { Id = id });
            var rentalPeriodDto = new GetRentalPeriodByIdDto
            {
                Id = rentalPeriod.Id,
                Name = rentalPeriod.Name
            };

            return Ok(GenericApiResponse<GetRentalPeriodByIdDto>.Success(rentalPeriodDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRentalPeriodDto createPricingPlanDto)
        {
            var command = new CreateRentalPeriodCommand
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
            var command = new UpdateRentalPeriodCommand
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
