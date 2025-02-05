﻿using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogCategoryByIdQuery : IRequest<GetBlogCategoryByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
