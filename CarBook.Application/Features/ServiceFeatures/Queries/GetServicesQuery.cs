using CarBook.Application.Features.ServiceFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ServiceFeatures.Queries
{
    public class GetServicesQuery : IRequest<List<GetServicesQueryResult>>
    {
    }
}
