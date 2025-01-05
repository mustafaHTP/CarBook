using CarBook.Application.Features.TestimonialFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.TestimonialFeatures.Queries
{
    public class GetTestimonialsQuery : IRequest<List<GetTestimonialsQueryResult>>
    {
    }
}
