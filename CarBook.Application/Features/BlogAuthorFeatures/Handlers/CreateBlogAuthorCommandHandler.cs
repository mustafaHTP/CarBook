using CarBook.Application.Features.BlogAuthorFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class CreateBlogAuthorCommandHandler : IRequestHandler<CreateBlogAuthorCommand>
    {
        private readonly IRepository<BlogAuthor> _repository;

        public CreateBlogAuthorCommandHandler(IRepository<BlogAuthor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogAuthorCommand request, CancellationToken cancellationToken)
        {
            var blogAuthor = new BlogAuthor()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
            };

            await _repository.CreateAsync(blogAuthor);
        }
    }
}
