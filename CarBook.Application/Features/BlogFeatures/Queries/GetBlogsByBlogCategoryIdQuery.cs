using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogsByBlogCategoryIdQuery : IRequest<IEnumerable<GetBlogsByBlogCategoryIdQueryResult>>
    {
        public int BlogCategoryId { get; set; }
        public string? Includes { get; set; }
    }
}
