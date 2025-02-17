using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Results
{
    public class GetBrandHasMaxModelCountQueryResult
    {
        public string? BrandName { get; set; }
        public int ModelCount { get; set; }
    }
}
