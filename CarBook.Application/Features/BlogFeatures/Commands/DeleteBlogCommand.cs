using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class DeleteBlogCommand : IRequest
    {
        public int Id { get; set; }
    }
}
