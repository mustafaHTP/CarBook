using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Commands
{
    public class UpdateBlogTagCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
