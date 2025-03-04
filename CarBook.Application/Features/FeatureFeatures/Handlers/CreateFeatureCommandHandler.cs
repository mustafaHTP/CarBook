using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository, ICarFeatureRepository carFeatureRepository)
        {
            _repository = repository;
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = new Feature()
            {
                Name = request.Name,
            };

            await _repository.CreateAsync(feature);

            //Add this feature to all cars
            await _carFeatureRepository.AddCarFeatureToAllCarsAsync(feature.Id);
        }
    }
}
