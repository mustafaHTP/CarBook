﻿using CarBook.Application.Dtos.ModelDtos;

namespace CarBook.Application.Dtos.BrandDtos
{
    public class GetBrandsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ModelWithNameDto>? Models { get; set; }
    }
}
