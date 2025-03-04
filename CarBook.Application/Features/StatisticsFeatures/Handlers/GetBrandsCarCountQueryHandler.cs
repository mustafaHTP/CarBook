using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBrandsCarCountQueryHandler : IRequestHandler<GetBrandsCarCountQuery, IEnumerable<GetBrandsCarCountQueryResult>>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandsCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetBrandsCarCountQueryResult>> Handle(GetBrandsCarCountQuery request, CancellationToken cancellationToken)
        {
            var brands = _repository.GetAllBrands();
            var result = brands.Select(b => new GetBrandsCarCountQueryResult
            {
                BrandName = b.Name,
                CarCount = b.Models.Sum(m => m.Cars.Count)
            });

            return await Task.FromResult(result);
        }
    }
}
