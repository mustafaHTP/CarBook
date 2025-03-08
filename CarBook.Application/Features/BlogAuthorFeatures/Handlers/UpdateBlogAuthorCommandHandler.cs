using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogAuthorFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class UpdateBlogAuthorCommandHandler : IRequestHandler<UpdateBlogAuthorCommand>
    {
        private readonly IRepository<BlogAuthor> _repository;

        public UpdateBlogAuthorCommandHandler(IRepository<BlogAuthor> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogAuthorCommand request, CancellationToken cancellationToken)
        {
            var blogAuthor = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(BlogAuthor), request.Id);
            blogAuthor.Name = request.Name;
            blogAuthor.Description = request.Description;
            blogAuthor.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(blogAuthor);
        }
    }
}
