using CarBook.Application.Features.ServiceFeatures.Queries;
using CarBook.Application.Features.ServiceFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ServiceFeatures.Handlers
{
    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<GetServicesQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServicesQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetServicesQueryResult>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();

            return services.Select(s => new GetServicesQueryResult()
            {
                Description = s.Description,
                IconUrl = s.IconUrl,
                Id = s.Id,
                Title = s.Title,
            }).ToList();
        }
    }
}
