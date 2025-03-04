using CarBook.Application.Features.ContactFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact()
            {
                Email = request.Email,
                Message = request.Message,
                Name = request.Name,
                SendDate = request.SendDate,
                Subject = request.Subject,
            };

            await _repository.CreateAsync(contact);
        }
    }
}
