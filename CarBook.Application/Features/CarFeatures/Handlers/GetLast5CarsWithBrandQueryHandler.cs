using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetLast5CarsWithBrandQueryHandler : IRequestHandler<GetLast5CarsWithBrandQuery, List<GetLast5CarsWithBrandQueryResult>>
    {
        private ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle(GetLast5CarsWithBrandQuery request, CancellationToken cancellationToken)
        {
            var cars = _repository.GetLast5CarsWithBrand();
            var result = cars.Select(c => new GetLast5CarsWithBrandQueryResult
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.Model.BrandId,
                Brand = c.Model.Brand,
                Km = c.Km,
                SeatCount = c.SeatCount,
                Luggage = c.Luggage,
                TransmissionType = c.TransmissionType,
                FuelType = c.FuelType,
                CoverImageUrl = c.CoverImageUrl,
                BigImageUrl = c.BigImageUrl
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}
