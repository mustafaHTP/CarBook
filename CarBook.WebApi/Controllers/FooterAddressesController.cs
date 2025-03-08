using CarBook.Application.Dtos.FooterAddressDtos;
using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Features.FooterAddressFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var footerAddresses = await _mediator.Send(new GetFooterAddressesQuery());
            var footerAddressDtos = footerAddresses.Select(footerAddress => new GetFooterAddressesDto
            {
                Id = footerAddress.Id,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Email = footerAddress.Email,
                Phone = footerAddress.Phone
            }).ToList();

            return Ok(footerAddressDtos);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<FooterAddress>))]
        public async Task<IActionResult> GetById(int id)
        {
            var footerAddress = await _mediator.Send(new GetFooterAddressByIdQuery() { Id = id });
            var footerAddressDto = new GetFooterAddressesDto
            {
                Id = footerAddress.Id,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Email = footerAddress.Email,
                Phone = footerAddress.Phone
            };

            return Ok(footerAddressDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressDto createFooterAddressDto)
        {
            var command = new CreateFooterAddressCommand
            {
                Description = createFooterAddressDto.Description,
                Address = createFooterAddressDto.Address,
                Email = createFooterAddressDto.Email,
                Phone = createFooterAddressDto.Phone
            };

            await _mediator.Send(command);

            return Ok("Footer Address has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<FooterAddress>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateFooterAddressDto updateFooterAddressDto)
        {
            var command = new UpdateFooterAddressCommand
            {
                Id = id,
                Description = updateFooterAddressDto.Description,
                Address = updateFooterAddressDto.Address,
                Email = updateFooterAddressDto.Email,
                Phone = updateFooterAddressDto.Phone
            };

            await _mediator.Send(command);

            return Ok("Footer Address has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<FooterAddress>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteFooterAddressCommand { Id = id };

            await _mediator.Send(command);

            return Ok("Footer Address has been deleted");
        }
    }
}
