using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogTagCloudDtos
{
    public class GetBlogTagsByBlogIdDto
    {
        public int Id { get; set; }
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
        public int BlogId { get; set; }
    }
}
