using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.ModelDtos;
using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Features.ModelFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetModelsQuery getModelsQuery)
        {
            var models = await _mediator.Send(getModelsQuery);
            var modelsDto = models.Select(m => new GetModelsDto()
            {
                Id = m.Id,
                Name = m.Name,
                BrandId = m.BrandId,
                Brand = new BrandWithNameDto()
                {
                    Id = m.Brand?.Id,
                    Name = m.Brand?.Name
                },
                Cars = m.Cars
            });

            return Ok(modelsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _mediator.Send(new GetModelByIdQuery() { Id = id });

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelCommand createModelCommand)
        {
            await _mediator.Send(createModelCommand);

            return Ok("Model has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateModelCommand updateModelCommand)
        {
            await _mediator.Send(updateModelCommand);

            return Ok("Model has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteModelCommand deleteModelCommand)
        {
            await _mediator.Send(deleteModelCommand);

            return Ok("Model has been deleted");
        }
    }
}
