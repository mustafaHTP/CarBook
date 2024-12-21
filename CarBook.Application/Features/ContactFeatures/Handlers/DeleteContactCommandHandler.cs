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
    public class DeleteContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public DeleteContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteContactCommand deleteContactCommand)
        {
            var contactToBeDeleted = await _repository.GetByIdAsync(deleteContactCommand.Id);
            await _repository.DeleteAsync(contactToBeDeleted);
        }
    }
}
