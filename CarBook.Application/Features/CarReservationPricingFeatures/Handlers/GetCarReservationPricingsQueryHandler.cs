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

            var rentalPeriods = request.RentalPeriods?.Split(',').ToList();
            var carReservationPricings = _repository.GetAll(rentalPeriods);
            var result = carReservationPricings.Select(crp => new GetCarReservationPricingsQueryResult()
            {
                Id = crp.Id,
                CarId = crp.CarId,
                Car = crp.Car,
                PricingPlanId = crp.PricingPlanId,
                PricingPlan = crp.PricingPlan,
                Price = crp.Price
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
