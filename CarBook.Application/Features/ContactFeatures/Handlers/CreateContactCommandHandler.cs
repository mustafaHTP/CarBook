using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand createContactCommand)
        {
            var contactToBeCreated = new Contact()
            {
                Email = createContactCommand.Email,
                Message = createContactCommand.Message,
                Name = createContactCommand.Name,
                SendDate = createContactCommand.SendDate,
                Subject = createContactCommand.Subject,
            };

            await _repository.CreateAsync(contactToBeCreated);
        }
    }
}
