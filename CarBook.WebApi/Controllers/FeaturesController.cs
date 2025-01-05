using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Features.FeatureFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var features = await _mediator.Send(new GetAllFeaturesQuery());

            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feature = await _mediator.Send(new GetFeatureByIdQuery(id));

            return Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureCommand createFeatureCommand)
        {
            await _mediator.Send(createFeatureCommand);

            return Ok("Feature has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureCommand updateFeatureCommand)
        {
            await _mediator.Send(updateFeatureCommand);

            return Ok("Feature has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFeatureCommand() { Id = id });

            return Ok("Feature has been deleted");
        }
    }
}
