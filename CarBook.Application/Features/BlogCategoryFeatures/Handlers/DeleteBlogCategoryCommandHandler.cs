using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class DeleteBlogCategoryCommandHandler : IRequestHandler<DeleteBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;

        public DeleteBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var blogCategory = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(blogCategory);
        }
    }
}
