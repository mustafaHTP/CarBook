using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class UpdateRentalPeriodCommandHandler : IRequestHandler<UpdateRentaPeriodCommand>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public UpdateRentalPeriodCommandHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRentaPeriodCommand request, CancellationToken cancellationToken)
        {
            var reservationPricingToBeUpdated = await _repository.GetByIdAsync(request.Id);

            reservationPricingToBeUpdated.Name = request.Name;

            await _repository.UpdateAsync(reservationPricingToBeUpdated);
        }
    }
}
