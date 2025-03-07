using CarBook.Application.Exceptions;
using CarBook.Application.Features.ModelFeatures.Queries;
using CarBook.Application.Features.ModelFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, GetModelByIdQueryResult>
    {
        private readonly IModelRepository _repository;

        public GetModelByIdQueryHandler(IModelRepository repository)
        {
            _repository = repository;
        }

        public Task<GetModelByIdQueryResult> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            var model = _repository.GetById(request.Id)
                ?? throw new NotFoundException<Model>(request.Id);

            var result = new GetModelByIdQueryResult()
            {
                Id = model.Id,
                BrandId = model.BrandId,
                Brand = model.Brand,
                Name = model.Name,
            };

            return Task.FromResult(result);
        }
    }
}
