using CarBook.Application.Features.CarReservationPricingFeatures.Queries;
using CarBook.Application.Features.CarReservationPricingFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Handlers
{
    public class GetCarReservationPricingsWithDayPricingPlanQueryHandler : IRequestHandler<GetCarReservationPricingsWithDayPricingPlanQuery, List<GetCarReservationPricingsWithDayPricingPlanQueryResult>>
    {
        private readonly ICarReservationPricingRepository _repository;

        public GetCarReservationPricingsWithDayPricingPlanQueryHandler(ICarReservationPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarReservationPricingsWithDayPricingPlanQueryResult>> Handle(GetCarReservationPricingsWithDayPricingPlanQuery request, CancellationToken cancellationToken)
        {
            var carReservationPricings = _repository.GetAllWithCarAndDayPricePlan();
            var result = carReservationPricings.Select(x => new GetCarReservationPricingsWithDayPricingPlanQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                Car = x.Car,
                PricingPlanId = x.RentalPeriodId,
                PricingPlan = x.RentalPeriod,
                Price = x.Price
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
