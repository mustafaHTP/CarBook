using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Features.ContactFeatures.Queries;
using CarBook.Application.Features.ContactFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery)
        {
            var contact = await _repository.GetByIdAsync(getContactByIdQuery.Id);

            return new GetContactByIdQueryResult()
            {
                Id = contact.Id,
                Email = contact.Email,
                Message = contact.Message,
                Name = contact.Name,
                SendDate = contact.SendDate,
                Subject = contact.Subject,
            };

        }
    }
}
