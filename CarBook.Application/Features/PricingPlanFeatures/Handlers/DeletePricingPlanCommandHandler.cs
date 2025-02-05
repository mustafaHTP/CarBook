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
