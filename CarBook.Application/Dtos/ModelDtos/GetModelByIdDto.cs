using CarBook.Application.Dtos.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.ModelDtos
{
    public class GetModelByIdDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
