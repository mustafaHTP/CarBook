using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Commands
{
    public class DeleteBlogCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
