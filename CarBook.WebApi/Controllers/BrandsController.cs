using CarBook.Application.Dtos.BrandDtos;
using CarBook.Application.Dtos.ModelDtos;
using CarBook.Application.Features.BrandFeatures.Commands;
using CarBook.Application.Features.BrandFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetBrandsQuery getBrandsQuery)
        {
            var brands = await _mediator.Send(getBrandsQuery);
            var brandsDto = brands.Select(b => new GetBrandsDto
            {
                Id = b.Id,
                Name = b.Name,
                Models = b.Models?.Select(m => new ModelWithNameDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    BrandId = m.BrandId
                }).ToList()
            }).ToList();

            return Ok(brandsDto);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Brand>))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBrandByIdQuery(id);
            var brand = await _mediator.Send(query);
            var brandDto = new GetBrandByIdDto()
            {
                Id = brand.Id,
                Name = brand.Name,
            };

            return Ok(brandDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            var createBrandCommand = new CreateBrandCommand()
            {
                Name = createBrandDto.Name
            };

            await _mediator.Send(createBrandCommand);

            return Ok("Brand has been created");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Brand>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBrandCommand(id);
            await _mediator.Send(command);

            return Ok("Brand has been deleted");
        }


        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Brand>))]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateBrandDto updateBrandDto)
        {
            var updateBrandCommand = new UpdateBrandCommand()
            {
                Id = id,
                Name = updateBrandDto.Name
            };

            await _mediator.Send(updateBrandCommand);

            return Ok("Brand has been updated");
        }
    }
}
