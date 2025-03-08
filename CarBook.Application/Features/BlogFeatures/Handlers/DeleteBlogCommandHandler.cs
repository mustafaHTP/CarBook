using CarBook.Application.Exceptions;
using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public DeleteBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Blog), request.Id);

            await _repository.DeleteAsync(blog);
        }
    }
}
