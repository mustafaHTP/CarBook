using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Features.FooterAddressFeatures.Queries;
using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Features.LocationFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
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

            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _mediator.Send(new GetLocationByIdQuery() { Id = id });

            return Ok(location);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommand createLocationCommand)
        {
            await _mediator.Send(createLocationCommand);

            return Ok("Location has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocationCommand updateLocationCommand)
        {
            await _mediator.Send(updateLocationCommand);

            return Ok("Location has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteLocationCommand deleteLocationCommand)
        {
            await _mediator.Send(deleteLocationCommand);

            return Ok("Location has been deleted");
        }
    }
}
