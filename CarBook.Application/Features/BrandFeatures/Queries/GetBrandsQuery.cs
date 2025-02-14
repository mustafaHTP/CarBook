using CarBook.Application.Features.BrandFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeatures.Queries
{
    public class GetBrandsQuery : IRequest<List<GetBrandsQueryResult>>
    {
        public bool IncludeModels { get; set; }
    }
}
