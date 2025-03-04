using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class DeletePricingPlanCommandHandler : IRequestHandler<DeletePricingPlanCommand>
    {
        private readonly IRepository<PricingPlan> _repository;

        public DeletePricingPlanCommandHandler(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeletePricingPlanCommand request, CancellationToken cancellationToken)
        {
            var pricingPlan = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(pricingPlan);
        }
    }
}
