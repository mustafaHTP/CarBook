using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Commands
{
    public class CreateBlogAuthorCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
