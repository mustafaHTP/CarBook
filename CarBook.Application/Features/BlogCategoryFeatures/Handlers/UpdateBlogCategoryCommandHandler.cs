using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
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
            var blogCategory = await _repository.GetByIdAsync(request.Id);

            //update here
            blogCategory.Name = request.Name;

            await _repository.UpdateAsync(blogCategory);
        }
    }
}
