using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Commands
{
    public class CreateBlogCommentCommand : IRequest
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
