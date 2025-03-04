using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Application.Features.PricingPlanFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class GetPricingPlansQueryHandler : IRequestHandler<GetPricingPlansQuery, List<GetPricingPlansQueryResult>>
    {
        private readonly IRepository<PricingPlan> _repository;

        public GetPricingPlansQueryHandler(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingPlansQueryResult>> Handle(GetPricingPlansQuery request, CancellationToken cancellationToken)
        {
            var reservationPricings = await _repository.GetAllAsync();

            return reservationPricings.Select(r => new GetPricingPlansQueryResult()
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();
        }
    }
}
