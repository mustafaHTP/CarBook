using CarBook.Application.Exceptions;
using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Location).Name, request.Id.ToString());

            //update here
            location.Name = request.Name;

            await _repository.UpdateAsync(location);
        }
    }
}
