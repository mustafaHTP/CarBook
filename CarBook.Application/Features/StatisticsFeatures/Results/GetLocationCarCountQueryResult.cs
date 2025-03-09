using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Results
{
    public class GetLocationCarCountQueryResult
    {
        public string LocationName { get; set; } = null!;
        public int CarCount { get; set; }
    }
}
