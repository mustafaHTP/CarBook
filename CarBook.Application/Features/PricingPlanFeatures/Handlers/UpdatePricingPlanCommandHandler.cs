using CarBook.Application.Features.ReservationPricingFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Handlers
{
    public class UpdatePricingPlanCommandHandler : IRequestHandler<UpdatePricingPlanCommand>
    {
        private readonly IRepository<PricingPlan> _repository;

        public UpdatePricingPlanCommandHandler(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingPlanCommand request, CancellationToken cancellationToken)
        {
            var reservationPricingToBeUpdated = await _repository.GetByIdAsync(request.Id);

            reservationPricingToBeUpdated.Name = request.Name;

            await _repository.UpdateAsync(reservationPricingToBeUpdated);
        }
    }
}
