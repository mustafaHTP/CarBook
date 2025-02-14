using CarBook.Application.Dtos.ModelDtos;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BrandDtos
{
    public class GetBrandsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ModelWithNameDto>? Models { get; set; }
    }
}
