using CarBook.Application.Dtos.BlogDtos;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogAuthorDtos
{
    public class GetBlogAuthorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<BlogLiteDto>? Blogs { get; set; }
    }
}
