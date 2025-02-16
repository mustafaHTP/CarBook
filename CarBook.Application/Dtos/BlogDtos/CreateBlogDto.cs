using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogDtos
{
    public class CreateBlogDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
