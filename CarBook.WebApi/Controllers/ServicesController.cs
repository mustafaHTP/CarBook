using CarBook.Application.Dtos.ServiceDtos;
using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Features.ServiceFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var services = await _mediator.Send(new GetServicesQuery());
            var serviceDtos = services.Select(service => new GetServicesDto
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            });

            return Ok(serviceDtos);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Service>))]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _mediator.Send(new GetServiceByIdQuery() { Id = id });
            var serviceDto = new GetServiceByIdDto
            {
                Id = service.Id,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };

            return Ok(serviceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceDto createServiceDto)
        {
            var command = new CreateServiceCommand
            {
                Title = createServiceDto.Title,
                Description = createServiceDto.Description,
                IconUrl = createServiceDto.IconUrl
            };

            await _mediator.Send(command);

            return Ok("Service has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Service>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateServiceDto updateServiceDto)
        {
            var command = new UpdateServiceCommand
            {
                Id = id,
                Title = updateServiceDto.Title,
                Description = updateServiceDto.Description,
                IconUrl = updateServiceDto.IconUrl
            };

            await _mediator.Send(command);

            return Ok("Service has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Service>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteServiceCommand { Id = id };

            await _mediator.Send(command);

            return Ok("Service has been deleted");
        }
    }
}
