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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand updateContactCommand)
        {
            var contactToBeUpdated = await _repository.GetByIdAsync(updateContactCommand.Id);

            contactToBeUpdated.Email = updateContactCommand.Email;
            contactToBeUpdated.Message = updateContactCommand.Message;
            contactToBeUpdated.Name = updateContactCommand.Name;
            contactToBeUpdated.SendDate = updateContactCommand.SendDate;
            contactToBeUpdated.Subject = updateContactCommand.Subject;

            await _repository.UpdateAsync(contactToBeUpdated);
        }
    }
}
