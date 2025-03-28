﻿using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class UpdateRentalPeriodCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
