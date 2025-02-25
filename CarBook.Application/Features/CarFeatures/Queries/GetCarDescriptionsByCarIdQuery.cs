using CarBook.Application.Features.CarFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarDescriptionsByCarIdQuery : IRequest<IEnumerable<GetCarDescriptionsByCarIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
