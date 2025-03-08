using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarByIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = _repository.GetById(request.Id)
                ?? throw new NotFoundException(typeof(Car), request.Id);

            var result = new GetCarByIdQueryResult()
            {
                Id = car.Id,
                ModelId = car.ModelId,
                Model = car.Model,
                Km = car.Km,
                SeatCount = car.SeatCount,
                Luggage = car.Luggage,
                TransmissionType = car.TransmissionType,
                FuelType = car.FuelType,
                CoverImageUrl = car.CoverImageUrl,
                BigImageUrl = car.BigImageUrl
            };

            return await Task.FromResult(result);
        }
    }
}
