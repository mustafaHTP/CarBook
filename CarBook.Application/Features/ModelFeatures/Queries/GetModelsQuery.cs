using CarBook.Application.Features.ModelFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Queries
{
    public class GetModelsQuery : IRequest<List<GetModelsQueryResult>>
    {
        public bool IncludeBrand { get; set; }
        public bool IncludeCars { get; set; }
    }
}
