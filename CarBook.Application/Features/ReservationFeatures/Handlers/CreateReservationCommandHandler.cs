using CarBook.Application.Features.ReservationFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ReservationFeatures.Handlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                CarId = request.CarId,
                CustomerFirstName = request.CustomerName,
                CustomerLastName = request.CustomerLastName,
                CustomerEmail = request.CustomerEmail,
                CustomerAge = request.CustomerAge,
                CustomerDriverLicenseYear = request.CustomerDriverLicenseYear,
                Description = request.Description,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId
            };

            await _repository.CreateAsync(reservation);
        }
    }
}
