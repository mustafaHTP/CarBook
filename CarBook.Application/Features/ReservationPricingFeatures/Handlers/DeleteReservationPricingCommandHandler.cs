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
    public class DeleteReservationPricingCommandHandler : IRequestHandler<DeleteReservationPricingCommand>
    {
        private readonly IRepository<ReservationPricing> _repository;

        public DeleteReservationPricingCommandHandler(IRepository<ReservationPricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteReservationPricingCommand request, CancellationToken cancellationToken)
        {
            var reservationPricingToBeDeleted = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(reservationPricingToBeDeleted);
        }
    }
}
