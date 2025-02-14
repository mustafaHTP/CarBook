using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Features.ContactFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> ContactList()
        {
            var contacts = await _mediator.Send(new GetContactsQuery());

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetContactByIdQuery(id);
            var contact = await _mediator.Send(query);

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand createContactCommand)
        {
            await _mediator.Send(createContactCommand);

            return Ok("Contact has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);

            await _mediator.Send(command);

            return Ok("Contact has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand updateContactCommand)
        {
            await _mediator.Send(updateContactCommand);

            return Ok("Contact has been updated");
        }
    }
}
