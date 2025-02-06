using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Results
{
    public class GetBlogByIdWithAuthorQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public string BlogAuthorName { get; set; }
        public string BlogAuthorDescription { get; set; }
        public string BlogAuthorImageUrl { get; set; }
    }
}
