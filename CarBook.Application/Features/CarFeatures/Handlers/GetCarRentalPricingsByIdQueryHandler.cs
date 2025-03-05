using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarRentalPricingsByIdQueryHandler : IRequestHandler<GetCarRentalPricingsByIdQuery, IEnumerable<GetCarRentalPricingsByIdQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarRentalPricingsByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarRentalPricingsByIdQueryResult>> Handle(GetCarRentalPricingsByIdQuery request, CancellationToken cancellationToken)
        {
            var carRentalPricings = _repository.GetCarRentalPricingsByCarId(request.CarId);
            var result = carRentalPricings.Select(crp => new GetCarRentalPricingsByIdQueryResult
            {
                CarId = crp.CarId,
                Car = crp.Car,
                Id = crp.Id,
                PricingPlan = crp.RentalPeriod,
                PricingPlanId = crp.RentalPeriodId,
                Price = crp.Price
            });

            return await Task.FromResult(result);
        }
    }
}
