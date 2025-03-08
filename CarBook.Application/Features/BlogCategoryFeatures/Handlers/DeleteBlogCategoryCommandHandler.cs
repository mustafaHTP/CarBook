using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogCategoryFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Handlers
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
            var blogCategory = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogCategory), request.Id);

            await _repository.DeleteAsync(blogCategory);
        }
    }
}
