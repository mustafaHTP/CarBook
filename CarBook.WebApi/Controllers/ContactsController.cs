using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Handlers;
using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Features.ContactFeatures.Handlers;
using CarBook.Application.Features.ContactFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly DeleteContactCommandHandler _deleteContactCommandHandler;
        private readonly GetContactsQueryHandler _getAllContactsQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, 
            UpdateContactCommandHandler updateContactCommandHandler, 
            DeleteContactCommandHandler deleteContactCommandHandler, 
            GetContactsQueryHandler getAllContactsQueryHandler, 
            GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _deleteContactCommandHandler = deleteContactCommandHandler;
            _getAllContactsQueryHandler = getAllContactsQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var contacts = await _getAllContactsQueryHandler.Handle();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetContactByIdQuery(id);
            var contact = await _getContactByIdQueryHandler.Handle(query);

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand createContactCommand)
        {
            await _createContactCommandHandler.Handle(createContactCommand);

            return Ok("Contact has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);
            await _deleteContactCommandHandler.Handle(command);

            return Ok("Contact has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand updateContactCommand)
        {
            await _updateContactCommandHandler.Handle(updateContactCommand);

            return Ok("Contact has been updated");
        }
    }
}
