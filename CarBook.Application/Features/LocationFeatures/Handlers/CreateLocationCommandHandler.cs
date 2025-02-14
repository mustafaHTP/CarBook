using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToBeCreated = new Location()
            {
                Name = request.Name
            };

            await _repository.CreateAsync(locationToBeCreated);
        }
    }
}
