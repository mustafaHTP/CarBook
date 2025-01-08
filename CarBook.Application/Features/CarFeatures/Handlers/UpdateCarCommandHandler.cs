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

        //public async Task Handle(UpdateCarCommand request)
        //{
        //    var carToBeUpdated = await _repository.GetByIdAsync(request.Id);

        //    carToBeUpdated.Id = request.Id;
        //    carToBeUpdated.ModelId = request.ModelId;
        //    carToBeUpdated.BigImageUrl = request.BigImageUrl;
        //    carToBeUpdated.CoverImageUrl = request.CoverImageUrl;
        //    carToBeUpdated.FuelType = request.FuelType;
        //    carToBeUpdated.Km = request.Km;
        //    carToBeUpdated.Luggage = request.Luggage;
        //    carToBeUpdated.SeatCount = request.SeatCount;
        //    carToBeUpdated.TransmissionType = request.TransmissionType;

        //    await _repository.UpdateAsync(carToBeUpdated);
        //}

        public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var carToBeUpdated = await _repository.GetByIdAsync(request.Id);

            carToBeUpdated.Id = request.Id;
            carToBeUpdated.ModelId = request.ModelId;
            carToBeUpdated.BigImageUrl = request.BigImageUrl;
            carToBeUpdated.CoverImageUrl = request.CoverImageUrl;
            carToBeUpdated.FuelType = request.FuelType;
            carToBeUpdated.Km = request.Km;
            carToBeUpdated.Luggage = request.Luggage;
            carToBeUpdated.SeatCount = request.SeatCount;
            carToBeUpdated.TransmissionType = request.TransmissionType;

            await _repository.UpdateAsync(carToBeUpdated);
        }
    }
}
