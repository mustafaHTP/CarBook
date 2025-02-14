using CarBook.Application.Features.ContactFeatures.Queries;
using CarBook.Application.Features.ContactFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetByIdAsync(request.Id);
            var result = new GetContactByIdQueryResult()
            {
                Id = contact.Id,
                Email = contact.Email,
                Message = contact.Message,
                Name = contact.Name,
                SendDate = contact.SendDate,
                Subject = contact.Subject,
            };

            return await Task.FromResult(result);
        }
    }
}
