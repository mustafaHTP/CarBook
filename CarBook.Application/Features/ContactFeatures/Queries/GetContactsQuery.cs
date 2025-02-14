using CarBook.Application.Features.ContactFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Queries
{
    public class GetContactsQuery : IRequest<List<GetContactsQueryResult>>
    {
    }
}
