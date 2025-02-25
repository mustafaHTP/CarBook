using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarRentalPricingsQueryHandler : IRequestHandler<GetCarRentalPricingsQuery, IEnumerable<GetCarRentalPricingsQueryResult>>
    {
        private readonly ICarRepository _repository;

        public GetCarRentalPricingsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarRentalPricingsQueryResult>> Handle(GetCarRentalPricingsQuery request, CancellationToken cancellationToken)
        {
            var rentalPricings = _repository.GetAllRentalPricings(request.IncludeCar);
            var result = rentalPricings.Select(rp => new GetCarRentalPricingsQueryResult
            {
                Id = rp.Id,
                CarId = rp.CarId,
                Car = rp.Car,
                PricingPlanId = rp.PricingPlanId,
                PricingPlan = rp.PricingPlan,
                Price = rp.Price
            });

            return await Task.FromResult(result);
        }
    }
}
