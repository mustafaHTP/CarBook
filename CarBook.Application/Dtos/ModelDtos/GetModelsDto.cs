﻿using CarBook.Application.Dtos.BrandDtos;
using CarBook.Domain.Entities;

namespace CarBook.Application.Dtos.ModelDtos
{
    public class GetModelsDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public BrandWithNameDto? Brand { get; set; }
        public string Name { get; set; } = null!;
        public List<Car>? Cars { get; set; }
    }
}
