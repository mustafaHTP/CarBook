using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Commands
{
    public class UpdateBlogAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
