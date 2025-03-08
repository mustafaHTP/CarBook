using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.ContactDtos;
using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Features.ContactFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _mediator.Send(new GetContactsQuery());
            var contactsDto = contacts.Select(c => new GetContactsDto()
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Subject = c.Subject,
                Message = c.Message,
                SendDate = c.SendDate
            });

            return Ok(GenericApiResponse<IEnumerable<GetContactsDto>>.Success(contactsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Contact>))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetContactByIdQuery(id);
            var contact = await _mediator.Send(query);
            var contactDto = new GetContactByIdDto()
            {
                Id = contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                Subject = contact.Subject,
                Message = contact.Message,
                SendDate = contact.SendDate
            };

            return Ok(GenericApiResponse<GetContactByIdDto>.Success(contactDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            var command = new CreateContactCommand()
            {
                Name = createContactDto.Name,
                Email = createContactDto.Email,
                Subject = createContactDto.Subject,
                Message = createContactDto.Message,
                SendDate = createContactDto.SendDate
            };

            await _mediator.Send(command);

            return Ok("Contact has been created");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Contact>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);

            await _mediator.Send(command);

            return Ok("Contact has been deleted");
        }


        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Contact>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateContactDto updateContactDto)
        {
            var command = new UpdateContactCommand()
            {
                Id = id,
                Name = updateContactDto.Name,
                Email = updateContactDto.Email,
                Subject = updateContactDto.Subject,
                Message = updateContactDto.Message,
                SendDate = updateContactDto.SendDate
            };

            await _mediator.Send(command);

            return Ok("Contact has been updated");
        }
    }
}
