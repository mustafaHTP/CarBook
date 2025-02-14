using CarBook.Application.Features.ModelFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Queries
{
    public class GetModelByIdQuery : IRequest<GetModelByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
