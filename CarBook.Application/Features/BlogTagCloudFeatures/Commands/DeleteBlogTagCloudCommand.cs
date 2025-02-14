using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Commands
{
    public class DeleteBlogTagCloudCommand : IRequest
    {
        public int Id { get; set; }
    }
}
