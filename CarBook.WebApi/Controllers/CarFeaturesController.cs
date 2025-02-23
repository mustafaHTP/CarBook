using CarBook.Application.Dtos.CarFeatureDtos;
using CarBook.Application.Features.CarFeatureFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
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
