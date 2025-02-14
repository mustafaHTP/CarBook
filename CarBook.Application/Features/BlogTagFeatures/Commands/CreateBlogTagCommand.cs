using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Commands
{
    public class CreateBlogTagCommand : IRequest
    {
        public string Name { get; set; }
    }
}
