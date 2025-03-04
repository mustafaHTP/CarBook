using CarBook.Application.Features.ReservationPricingFeatures.Queries;
using CarBook.Application.Features.ReservationPricingFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Handlers
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
