﻿using CarBook.Application.Features.BlogCommentFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogCommentFeatures.Queries
{
    public class GetBlogCommentsByBlogIdQuery : IRequest<List<GetBlogCommentsByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
    }
}
