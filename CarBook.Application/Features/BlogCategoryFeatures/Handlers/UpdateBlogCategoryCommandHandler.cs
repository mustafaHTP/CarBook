using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogCategoryFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCategoryFeatures.Handlers
{
    public class UpdateBlogCategoryCommandHandler : IRequestHandler<UpdateBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;

        public UpdateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var blogCategory = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogCategory).Name, request.Id.ToString());

            //update here
            blogCategory.Name = request.Name;

            await _repository.UpdateAsync(blogCategory);
        }
    }
}
