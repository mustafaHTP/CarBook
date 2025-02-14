using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class CreateBlogCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
