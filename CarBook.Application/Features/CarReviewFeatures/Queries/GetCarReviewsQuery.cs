using CarBook.Application.Features.CarReviewFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReviewFeatures.Queries
{
    public class GetCarReviewsQuery : IRequest<IEnumerable<GetCarReviewsQueryResult>>
    {
    }
}
