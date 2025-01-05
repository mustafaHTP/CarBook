using CarBook.Application.Features.SocialMediaFeatures.Commands;
using CarBook.Application.Features.SocialMediaFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socialMedias = await _mediator.Send(new GetSocialMediasQuery());

            return Ok(socialMedias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaByIdQuery() { Id = id });

            return Ok(socialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand createSocialMediaCommand)
        {
            await _mediator.Send(createSocialMediaCommand);

            return Ok("Socia lMedia has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            await _mediator.Send(updateSocialMediaCommand);

            return Ok("Social Media has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            await _mediator.Send(deleteSocialMediaCommand);

            return Ok("Social Media has been deleted");
        }
    }
}
