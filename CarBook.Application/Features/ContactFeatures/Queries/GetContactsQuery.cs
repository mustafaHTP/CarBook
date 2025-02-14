using CarBook.Application.Features.ContactFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ContactFeatures.Queries
{
    public class GetContactsQuery : IRequest<List<GetContactsQueryResult>>
    {
    }
}
