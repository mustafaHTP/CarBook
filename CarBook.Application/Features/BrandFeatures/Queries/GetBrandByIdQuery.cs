using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeatures.Queries
{
    public class GetBrandByIdQuery
    {
        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
