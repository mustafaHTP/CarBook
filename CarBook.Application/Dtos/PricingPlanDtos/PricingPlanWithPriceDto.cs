﻿namespace CarBook.Application.Dtos.PricingPlanDtos
{
    public class PricingPlanWithPriceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
