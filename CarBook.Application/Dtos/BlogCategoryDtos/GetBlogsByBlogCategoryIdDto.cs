using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogCategoryDtos
{
    public class GetBlogsByBlogCategoryIdDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public string BlogAuthorName { get; set; } = null!;
        public string BlogAuthorDescription { get; set; } = null!;
        public string BlogAuthorImageUrl { get; set; } = null!;
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; } = null!;
    }
}
