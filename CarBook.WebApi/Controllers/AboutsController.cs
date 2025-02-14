using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Features.AboutFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> AboutList()
        {
            var abouts = await _mediator.Send(new GetAboutsQuery());

            return Ok(abouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAboutByIdQuery(id);
            var about = await _mediator.Send(query);

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand createAboutCommand)
        {
            await _mediator.Send(createAboutCommand);

            return Ok("About has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAboutCommand(id);
            await _mediator.Send(command);

            return Ok("About has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommand updateAboutCommand)
        {
            await _mediator.Send(updateAboutCommand);

            return Ok("About has been updated");
        }
    }
}
