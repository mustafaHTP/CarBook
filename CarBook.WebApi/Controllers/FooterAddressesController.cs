using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Features.FooterAddressFeatures.Queries;
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

            return Ok(footerAddresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var footerAddress = await _mediator.Send(new GetFooterAddressByIdQuery() { Id = id });

            return Ok(footerAddress);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressCommand createFooterAddressCommand)
        {
            await _mediator.Send(createFooterAddressCommand);

            return Ok("Footer Address has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAddressCommand updateFooterAddressCommand)
        {
            await _mediator.Send(updateFooterAddressCommand);

            return Ok("Footer Address has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteFooterAddressCommand deleteFooterAddressCommand)
        {
            await _mediator.Send(deleteFooterAddressCommand);

            return Ok("Footer Address has been deleted");
        }
    }
}
