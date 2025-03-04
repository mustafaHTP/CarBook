using CarBook.Application.Features.ReservationPricingFeatures.Queries;
using CarBook.Application.Features.ReservationPricingFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Handlers
{
    public class GetPricingPlanByIdQueryHandler : IRequestHandler<GetPricingPlanByIdQuery, GetPricingPlanByIdQueryResult>
    {
        private readonly IRepository<PricingPlan> _repository;

        public GetPricingPlanByIdQueryHandler(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingPlanByIdQueryResult> Handle(GetPricingPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var pricingPlan = await _repository.GetByIdAsync(request.Id);

            return new GetPricingPlanByIdQueryResult()
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            };
        }
    }
}
