using CarBook.Application.Features.AboutFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AboutFeatures.Queries
{
    public class GetAboutsQuery : IRequest<List<GetAboutsQueryResult>>
    {
    }
}
