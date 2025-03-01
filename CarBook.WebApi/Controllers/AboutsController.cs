using CarBook.Application.Dtos.AboutDtos;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var abouts = await _mediator.Send(new GetAboutsQuery());
            var aboutsDto = abouts.Select(about => new GetAboutsDto
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            });

            return Ok(aboutsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAboutByIdQuery(id);
            var about = await _mediator.Send(query);
            var aboutDto = new GetAboutByIdDto
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };

            return Ok(aboutDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            var createAboutCommand = new CreateAboutCommand
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };
            await _mediator.Send(createAboutCommand);

            return Ok("About has been created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAboutCommand(id);
            await _mediator.Send(command);

            return Ok("About has been deleted");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAboutDto updateAboutDto)
        {
            var updateAboutCommand = new UpdateAboutCommand
            {
                Id = id,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };
            await _mediator.Send(updateAboutCommand);

            return Ok("About has been updated");
        }
    }
}
