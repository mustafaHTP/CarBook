using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;

        public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var blogCategory = new BlogCategory()
            {
                Name = request.Name
            };

            await _repository.CreateAsync(blogCategory);
        }
    }
}
