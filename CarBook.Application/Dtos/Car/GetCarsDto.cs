using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.Car
{
    public class GetCarsDto
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int Km { get; set; }
        public byte SeatCount { get; set; }
        public byte Luggage { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
