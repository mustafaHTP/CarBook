using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Car).Name, request.Id.ToString());

            car.Id = request.Id;
            car.ModelId = request.ModelId;
            car.BigImageUrl = request.BigImageUrl;
            car.CoverImageUrl = request.CoverImageUrl;
            car.FuelType = request.FuelType;
            car.Km = request.Km;
            car.Luggage = request.Luggage;
            car.SeatCount = request.SeatCount;
            car.TransmissionType = request.TransmissionType;

            await _repository.UpdateAsync(car);
        }
    }
}
