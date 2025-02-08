using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Results
{
    public class GetBlogTagCloudByIdQueryResult
    {
        public int Id { get; set; }
        public int BlogTagId { get; set; }
        public int BlogId { get; set; }
    }
}
