using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Commands
{
    public class CreateBlogCommentCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }
    }
}
