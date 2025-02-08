using CarBook.Application.Features.BlogCommentFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogCommentFeatures.Queries
{
    public class GetBlogCommentByIdQuery : IRequest<GetBlogCommentByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
