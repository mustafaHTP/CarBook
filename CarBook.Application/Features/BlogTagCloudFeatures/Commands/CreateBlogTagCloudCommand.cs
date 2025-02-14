using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Commands
{
    public class CreateBlogTagCloudCommand : IRequest
    {
        public int BlogTagId { get; set; }
        public int BlogId { get; set; }
    }
}
