using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var carToBeUpdated = await _repository.GetByIdAsync(updateCarCommand.Id);

            carToBeUpdated.Id = updateCarCommand.Id;
            carToBeUpdated.ModelId = updateCarCommand.ModelId;
            carToBeUpdated.BigImageUrl = updateCarCommand.BigImageUrl;
            carToBeUpdated.CoverImageUrl = updateCarCommand.CoverImageUrl;
            carToBeUpdated.FuelType = updateCarCommand.FuelType;
            carToBeUpdated.Km = updateCarCommand.Km;
            carToBeUpdated.Luggage = updateCarCommand.Luggage;
            carToBeUpdated.SeatCount = updateCarCommand.SeatCount;
            carToBeUpdated.TransmissionType = updateCarCommand.TransmissionType;

            await _repository.UpdateAsync(carToBeUpdated);
        }
    }
}
