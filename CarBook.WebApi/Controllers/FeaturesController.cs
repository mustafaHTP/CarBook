using CarBook.Application.Dtos.FeatureDtos;
using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Features.FeatureFeatures.Queries;
using MediatR;
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
            var featuresDto = features.Select(f => new GetFeaturesDto() 
            { 
                Id = f.Id, 
                Name = f.Name 
            });

            return Ok(featuresDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feature = await _mediator.Send(new GetFeatureByIdQuery(id));
            var featureDto = new GetFeatureByIdDto()
            {
                Id = feature.Id,
                Name = feature.Name
            };

            return Ok(featureDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            var createFeatureCommand = new CreateFeatureCommand() 
            { 
                Name = createFeatureDto.Name 
            };

            await _mediator.Send(createFeatureCommand);

            return Ok("Feature has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            var updateFeatureCommand = new UpdateFeatureCommand()
            {
                Id = updateFeatureDto.Id,
                Name = updateFeatureDto.Name
            };

            await _mediator.Send(updateFeatureCommand);

            return Ok("Feature has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteFeatureCommand() { Id = id });

            return Ok("Feature has been deleted");
        }
    }
}
