using CarBook.Application.Features.ContactFeatures.Queries;
using CarBook.Application.Features.ContactFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Handlers
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<GetContactsQueryResult>>
    {
        private readonly IRepository<Contact> _repository;

        public GetContactsQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactsQueryResult>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAllAsync();
            var result = contact.Select(c => new GetContactsQueryResult()
            {
                Id = c.Id,
                Email = c.Email,
                Message = c.Message,
                Name = c.Name,
                SendDate = c.SendDate,
                Subject = c.Subject,
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
