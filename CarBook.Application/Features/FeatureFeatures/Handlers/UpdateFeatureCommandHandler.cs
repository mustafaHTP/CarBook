using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Interfaces;
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
            var featureToBeUpdated = await _repository.GetByIdAsync(request.Id);
            //update here
            featureToBeUpdated.Name = request.Name;

            await _repository.UpdateAsync(featureToBeUpdated);
        }
    }
}
