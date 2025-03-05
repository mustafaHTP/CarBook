using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Application.Features.PricingPlanFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class GetRentaPeriodByIdQueryHandler : IRequestHandler<GetRentalPeriodByIdQuery, GetRentalPeriodByIdQueryResult>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public GetRentaPeriodByIdQueryHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task<GetRentalPeriodByIdQueryResult> Handle(GetRentalPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            var pricingPlan = await _repository.GetByIdAsync(request.Id);

            return new GetRentalPeriodByIdQueryResult()
            {
                Id = pricingPlan.Id,
                Name = pricingPlan.Name
            };
        }
    }
}
