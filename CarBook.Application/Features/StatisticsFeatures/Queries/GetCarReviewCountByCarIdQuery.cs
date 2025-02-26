using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetCarReviewCountByCarIdQuery : IRequest<GetCarReviewCountByCarIdQueryResult>
    {
        public int CarId { get; set; }
    }
}
