using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Features.ServiceFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Services = await _mediator.Send(new GetServicesQuery());

            return Ok(Services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Service = await _mediator.Send(new GetServiceByIdQuery() { Id = id });

            return Ok(Service);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand createServiceCommand)
        {
            await _mediator.Send(createServiceCommand);

            return Ok("Service has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceCommand updateServiceCommand)
        {
            await _mediator.Send(updateServiceCommand);

            return Ok("Service has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteServiceCommand deleteServiceCommand)
        {
            await _mediator.Send(deleteServiceCommand);

            return Ok("Service has been deleted");
        }
    }
}
