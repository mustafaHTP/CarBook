using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.ModelDtos
{
    public class ModelWithNameDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
