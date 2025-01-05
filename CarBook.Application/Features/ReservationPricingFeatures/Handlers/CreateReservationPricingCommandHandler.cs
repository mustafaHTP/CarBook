using CarBook.Application.Features.ReservationPricingFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ReservationPricingFeatures.Handlers
{
    public class CreateReservationPricingCommandHandler : IRequestHandler<CreateReservationPricingCommand>
    {
        private readonly IRepository<ReservationPricing> _repository;

        public CreateReservationPricingCommandHandler(IRepository<ReservationPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationPricingCommand request, CancellationToken cancellationToken)
        {
            var reservationPricingToBeCreated = new ReservationPricing()
            {
                Name = request.Name,
            };

            await _repository.CreateAsync(reservationPricingToBeCreated);
        }
    }
}
