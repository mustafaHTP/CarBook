using CarBook.Application.Features.ReservationPricingFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ReservationPricingFeatures.Queries
{
    public class GetPricingPlansQuery : IRequest<List<GetPricingPlansQueryResult>>
    {
    }
}
