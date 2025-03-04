using CarBook.Application.Features.ModelFeatures.Queries;
using CarBook.Application.Features.ModelFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, List<GetModelsQueryResult>>
    {
        private readonly IModelRepository _repository;

        public GetModelsQueryHandler(IModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetModelsQueryResult>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            var models = _repository.GetAll(request.IncludeCars);
            var result = models.Select(m => new GetModelsQueryResult()
            {
                Id = m.Id,
                BrandId = m.BrandId,
                Brand = m.Brand,
                Name = m.Name,
                Cars = m.Cars
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
