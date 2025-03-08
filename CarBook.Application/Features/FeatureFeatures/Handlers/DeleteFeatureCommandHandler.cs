using CarBook.Application.Exceptions;
using CarBook.Application.Features.FeatureFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Handlers
{
    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public DeleteFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Feature), request.Id);

            await _repository.DeleteAsync(feature);
        }
    }
}
