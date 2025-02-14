using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Commands
{
    public class DeleteBlogCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
