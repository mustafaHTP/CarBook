using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Commands
{
    public class DeleteBlogAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
