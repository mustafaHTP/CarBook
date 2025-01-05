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
    public class UpdateReservationPricingCommandHandler : IRequestHandler<UpdateReservationPricingCommand>
    {
        private readonly IRepository<ReservationPricing> _repository;

        public UpdateReservationPricingCommandHandler(IRepository<ReservationPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationPricingCommand request, CancellationToken cancellationToken)
        {
            var reservationPricingToBeUpdated = await _repository.GetByIdAsync(request.Id);

            reservationPricingToBeUpdated.Name = request.Name;

            await _repository.UpdateAsync(reservationPricingToBeUpdated);
        }
    }
}
