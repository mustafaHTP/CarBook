using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car()
            {
                ModelId = request.ModelId,
                BigImageUrl = request.BigImageUrl,
                CoverImageUrl = request.CoverImageUrl,
                FuelType = request.FuelType,
                Km = request.Km,
                Luggage = request.Luggage,
                SeatCount = request.SeatCount,
                TransmissionType = request.TransmissionType
            };

            await _repository.CreateAsync(car);
        }
    }
}
