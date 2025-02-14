using MediatR;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Commands
{
    public class UpdateBlogTagCloudCommand : IRequest
    {
        public int Id { get; set; }
        public int BlogTagId { get; set; }
        public int BlogId { get; set; }
    }
}
