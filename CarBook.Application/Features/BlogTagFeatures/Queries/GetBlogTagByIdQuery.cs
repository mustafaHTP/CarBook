using CarBook.Application.Features.BlogTagFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagFeatures.Queries
{
    public class GetBlogTagByIdQuery : IRequest<GetBlogTagByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
