using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.StatisticsDtos
{
    public class GetBrandsCarCountDto
    {
        public string BrandName { get; set; } = null!;
        public int CarCount { get; set; }
    }
}
