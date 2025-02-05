using CarBook.Application.Features.CarReservationPricingFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Queries
{
    public class GetCarReservationPricingsQuery : IRequest<List<GetCarReservationPricingsQueryResult>>
    {
    }
}
