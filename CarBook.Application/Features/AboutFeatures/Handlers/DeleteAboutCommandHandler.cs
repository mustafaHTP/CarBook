using CarBook.Application.Exceptions;
using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<About>(request.Id);

            await _repository.DeleteAsync(about);
        }
    }
}
