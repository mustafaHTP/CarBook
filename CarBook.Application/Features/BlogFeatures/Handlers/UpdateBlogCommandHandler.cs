using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Blog).Name, request.Id.ToString());

            // Update here
            blog.BlogAuthorId = request.BlogAuthorId;
            blog.BlogCategoryId = request.BlogCategoryId;
            blog.Title = request.Title;
            blog.Content = request.Content;
            blog.CoverImageUrl = request.CoverImageUrl;

            await _repository.UpdateAsync(blog);
        }
    }
}
