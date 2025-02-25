using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Results
{
    public class GetCarDescriptionsByCarIdQueryResult
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
