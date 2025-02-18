using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.StatisticsDtos
{
    public class GetBrandHasMaxModelCountDto
    {
        public string? BrandName { get; set; }
        public int ModelCount { get; set; }
    }
}
