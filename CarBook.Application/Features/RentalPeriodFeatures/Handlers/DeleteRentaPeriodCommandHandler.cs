using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class DeleteRentaPeriodCommandHandler : IRequestHandler<DeleteRentaPeriodCommand>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public DeleteRentaPeriodCommandHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteRentaPeriodCommand request, CancellationToken cancellationToken)
        {
            var pricingPlan = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(pricingPlan);
        }
    }
}
