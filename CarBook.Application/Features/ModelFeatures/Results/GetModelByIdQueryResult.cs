using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Results
{
    public class GetModelByIdQueryResult
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
