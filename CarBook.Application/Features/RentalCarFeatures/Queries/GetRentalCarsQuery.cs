using CarBook.Application.Features.RentalCarFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.RentalCarFeatures.Queries
{
    public class GetRentalCarsQuery : IRequest<IEnumerable<GetRentalCarsQueryResult>>
    {
        public int? LocationId { get; set; }
    }
}
