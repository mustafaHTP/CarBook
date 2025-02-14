using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Commands
{
    public class DeleteBlogTagCommand : IRequest
    {
        public int Id { get; set; }
    }
}
