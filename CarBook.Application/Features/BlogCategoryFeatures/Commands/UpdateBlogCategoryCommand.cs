using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Commands
{
    public class UpdateBlogCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
