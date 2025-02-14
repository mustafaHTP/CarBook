using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var car = await _repository.GetByIdAsync(request.Id);

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
