using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class UpdateBlogCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
