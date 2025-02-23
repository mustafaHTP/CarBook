using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Commands
{
    public class UpdateBlogCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
