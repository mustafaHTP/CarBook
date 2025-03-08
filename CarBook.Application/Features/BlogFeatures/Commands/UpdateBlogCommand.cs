using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class UpdateBlogCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
