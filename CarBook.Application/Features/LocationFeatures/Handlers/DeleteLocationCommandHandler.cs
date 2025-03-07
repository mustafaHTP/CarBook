using CarBook.Application.Exceptions;
using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public DeleteLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Location>(request.Id);

            await _repository.DeleteAsync(location);
        }
    }
}
