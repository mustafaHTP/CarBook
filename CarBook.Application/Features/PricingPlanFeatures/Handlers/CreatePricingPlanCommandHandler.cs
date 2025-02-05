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
    public class CreatePricingPlanCommandHandler : IRequestHandler<CreatePricingPlanCommand>
    {
        private readonly IRepository<PricingPlan> _repository;

        public CreatePricingPlanCommandHandler(IRepository<PricingPlan> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePricingPlanCommand request, CancellationToken cancellationToken)
        {
            var pricingPlan = new PricingPlan()
            {
                Name = request.Name,
            };

            await _repository.CreateAsync(pricingPlan);
        }
    }
}
