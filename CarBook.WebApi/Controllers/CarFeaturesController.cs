using CarBook.Application.Dtos.CarFeatureDtos;
using CarBook.Application.Features.CarFeatureFeatures.Commands;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<CarFeature>))]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateCarFeatureDto updateCarFeatureDto)
        {
            var command = new UpdateCarFeatureCommand
            {
                Id = id,
                IsAvailable = updateCarFeatureDto.IsAvailable,
            };

            await _mediator.Send(command);

            return Ok("Car Feature has been updated");
        }
    }
}
