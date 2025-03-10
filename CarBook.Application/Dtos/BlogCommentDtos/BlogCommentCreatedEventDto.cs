using CarBook.Application.Dtos.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogCommentDtos
{
    public class BlogCommentCreatedEventDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public BlogLiteDto Blog { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = null!;
    }
}
