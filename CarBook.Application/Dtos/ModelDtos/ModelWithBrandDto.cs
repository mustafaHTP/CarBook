using CarBook.Application.Dtos.BrandDtos;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.ModelDtos
{
    public class ModelWithBrandDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public BrandWithNameDto Brand { get; set; }
        public string Name { get; set; }
    }
}
