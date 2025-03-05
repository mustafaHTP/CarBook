using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Application.Features.PricingPlanFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class GetPricingPlansQueryHandler : IRequestHandler<GetRentalPeriodsQuery, List<GetRentalPeriodsQueryResult>>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public GetPricingPlansQueryHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentalPeriodsQueryResult>> Handle(GetRentalPeriodsQuery request, CancellationToken cancellationToken)
        {
            var reservationPricings = await _repository.GetAllAsync();

            return reservationPricings.Select(r => new GetRentalPeriodsQueryResult()
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();
        }
    }
}
