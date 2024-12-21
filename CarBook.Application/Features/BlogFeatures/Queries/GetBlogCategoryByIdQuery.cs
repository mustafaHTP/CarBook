﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogCategoryByIdQuery
    {
        public int Id { get; set; }

        public GetBlogCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
