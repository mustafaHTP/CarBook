using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class DeleteBlogCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
