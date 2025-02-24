using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarsQueryDto
    {
        public bool IncludeModel { get; set; }
        public bool IncludeBrand { get; set; }
    }
}
