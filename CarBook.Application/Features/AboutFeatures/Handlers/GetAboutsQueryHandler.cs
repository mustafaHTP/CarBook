using CarBook.Application.Features.AboutFeatures.Queries;
using CarBook.Application.Features.AboutFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class GetAboutsQueryHandler : IRequestHandler<GetAboutsQuery, List<GetAboutsQueryResult>>
    {
        private readonly IRepository<About> _repository;

        public GetAboutsQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutsQueryResult>> Handle(GetAboutsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            var queryResult = values.Select(x => new GetAboutsQueryResult()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToList();

            return queryResult;
        }
    }
}
