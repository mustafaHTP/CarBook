using CarBook.Application.Features.LocationFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.LocationFeatures.Queries
{
    public class GetLocationsQuery : IRequest<List<GetLocationsQueryResult>>
    {
    }
}
