using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand createCarCommand)
        {
            var carToBeCreated = new Car()
            {
                ModelId = createCarCommand.ModelId,
                BigImageUrl = createCarCommand.BigImageUrl,
                CoverImageUrl = createCarCommand.CoverImageUrl,
                FuelType = createCarCommand.FuelType,
                Km = createCarCommand.Km,
                Luggage = createCarCommand.Luggage,
                SeatCount = createCarCommand.SeatCount,
                TransmissionType = createCarCommand.TransmissionType
            };

            await _repository.CreateAsync(carToBeCreated);
        }
    }
}
