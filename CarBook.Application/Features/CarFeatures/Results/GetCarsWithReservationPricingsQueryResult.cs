﻿using CarBook.Domain.Entities;
using CarBook.Domain.Enums;

namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarsWithReservationPricingsQueryResult
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string BigImageUrl { get; set; } = null!;
        public List<CarReservationPricing> CarReservationPricings { get; set; } = null!;
    }
}
