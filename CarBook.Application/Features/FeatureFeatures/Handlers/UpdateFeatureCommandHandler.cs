using CarBook.Application.Exceptions;
using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Feature), request.Id);

            feature.Name = request.Name;

            await _repository.UpdateAsync(feature);
        }
    }
}
