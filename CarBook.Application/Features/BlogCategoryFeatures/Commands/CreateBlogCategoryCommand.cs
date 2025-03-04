using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Commands
{
    public class CreateBlogCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
