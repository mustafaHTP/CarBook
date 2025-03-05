using CarBook.Application.Dtos.CarDtos;
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
                BrandName = m.Brand.Name,
                Cars = m.Cars?.Select(c => new CarLiteDto
                {
                    Id = c.Id,
                    BrandId = c.Model.BrandId,
                    BrandName = c.Model.Brand.Name,
                    ModelId = c.ModelId,
                    ModelName = c.Model.Name,
                    BigImageUrl = c.BigImageUrl,
                    CoverImageUrl = c.CoverImageUrl,
                    FuelType = c.FuelType,
                    Km = c.Km,
                    Luggage = c.Luggage,
                    SeatCount = c.SeatCount,
                    TransmissionType = c.TransmissionType
                })
            });

            return Ok(modelsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _mediator.Send(new GetModelByIdQuery() { Id = id });
            var modelDto = new GetModelByIdDto
            {
                Id = model.Id,
                Name = model.Name,
                BrandId = model.BrandId,
                BrandName = model.Brand.Name
            };

            return Ok(modelDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModelDto createModelDto)
        {
            var command = new CreateModelCommand
            {
                BrandId = createModelDto.BrandId,
                Name = createModelDto.Name
            };

            await _mediator.Send(command);

            return Ok("Model has been created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateModelDto updateModelDto)
        {
            var command = new UpdateModelCommand
            {
                Id = id,
                Name = updateModelDto.Name,
                BrandId = updateModelDto.BrandId
            };

            await _mediator.Send(command);

            return Ok("Model has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteModelCommand() { Id = id };

            await _mediator.Send(command);

            return Ok("Model has been deleted");
        }
    }
}
