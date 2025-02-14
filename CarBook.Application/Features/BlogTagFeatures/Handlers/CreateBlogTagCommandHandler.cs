using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class CreateBlogTagCommandHandler : IRequestHandler<CreateBlogTagCommand>
    {
        private readonly IRepository<BlogTag> _repository;

        public CreateBlogTagCommandHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogTagCommand request, CancellationToken cancellationToken)
        {
            var blogTag = new BlogTag
            {
                Name = request.Name
            };

            await _repository.CreateAsync(blogTag);
        }
    }
}
