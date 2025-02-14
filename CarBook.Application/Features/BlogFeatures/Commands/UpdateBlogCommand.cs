using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class UpdateBlogCommand : IRequest
    {
        public int Id { get; set; }
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
