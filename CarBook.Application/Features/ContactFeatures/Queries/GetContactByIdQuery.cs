using CarBook.Application.Features.ContactFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Queries
{
    public class GetContactByIdQuery : IRequest<GetContactByIdQueryResult>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
