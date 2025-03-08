using CarBook.Application.Exceptions;
using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Contact), request.Id);

            contact.Email = request.Email;
            contact.Message = request.Message;
            contact.Name = request.Name;
            contact.SendDate = request.SendDate;
            contact.Subject = request.Subject;

            await _repository.UpdateAsync(contact);
        }
    }
}
