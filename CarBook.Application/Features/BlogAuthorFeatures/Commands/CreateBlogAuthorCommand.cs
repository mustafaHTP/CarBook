using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Commands
{
    public class CreateBlogAuthorCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
