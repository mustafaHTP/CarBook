using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class CreateBlogCommand : IRequest
    {
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
