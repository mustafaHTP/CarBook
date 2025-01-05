using CarBook.Application.Features.ReservationPricingFeatures.Results;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);

            return new GetServiceByIdQueryResult()
            {
                Id = service.Id,
                Description = service.Description,
                IconUrl = service.IconUrl,
                Title = service.Title
            };
        }
    }
}
