﻿using CarBook.Domain.Enums;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Commands
{
    public class CreateCarCommand : IRequest
    {
        public int ModelId { get; set; }
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; } = null!;
        public string BigImageUrl { get; set; } = null!;
    }
}
