using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.LocationDtos;
using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Features.LocationFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _mediator.Send(new GetLocationsQuery());
            var locationsDto = locations.Select(location => new GetLocationsDto() { Id = location.Id, Name = location.Name });

            return Ok(GenericApiResponse<IEnumerable<GetLocationsDto>>.Success(locationsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Location>))]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _mediator.Send(new GetLocationByIdQuery() { Id = id });
            var locationDto = new GetLocationByIdDto() { Id = location.Id, Name = location.Name };

            return Ok(GenericApiResponse<GetLocationByIdDto>.Success(locationDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationDto createLocationDto)
        {
            var command = new CreateLocationCommand() { Name = createLocationDto.Name };

            await _mediator.Send(command);

            return Ok("Location has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Location>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLocationDto updateLocationDto)
        {
            var command = new UpdateLocationCommand()
            {
                Id = id,
                Name = updateLocationDto.Name
            };

            await _mediator.Send(command);

            return Ok("Location has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Location>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteLocationCommand() { Id = id };

            await _mediator.Send(command);

            return Ok("Location has been deleted");
        }
    }
}
