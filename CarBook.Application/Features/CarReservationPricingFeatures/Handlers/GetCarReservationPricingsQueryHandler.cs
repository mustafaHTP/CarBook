using CarBook.Application.Features.CarReservationPricingFeatures.Queries;
using CarBook.Application.Features.CarReservationPricingFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Handlers
{
    public class GetCarReservationPricingsQueryHandler : IRequestHandler<GetCarReservationPricingsQuery, List<GetCarReservationPricingsQueryResult>>
    {
        private readonly ICarReservationPricingRepository _repository;

        public GetCarReservationPricingsQueryHandler(ICarReservationPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarReservationPricingsQueryResult>> Handle(GetCarReservationPricingsQuery request, CancellationToken cancellationToken)
        {
            var carReservationPricings = _repository.GetAllWithCarAndPricePlan();
            var result = carReservationPricings.Select(x => new GetCarReservationPricingsQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                Car = x.Car,
                PricingPlanId = x.PricingPlanId,
                PricingPlan = x.PricingPlan,
                Price = x.Price
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
