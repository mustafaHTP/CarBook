using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogsCountByBlogCategoryIdQuery : IRequest<GetBlogsCountByBlogCategoryIdQueryResult>
    {
        public int BlogCategoryId { get; set; }
    }
}
