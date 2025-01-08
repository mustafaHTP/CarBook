using CarBook.Application.Features.CarFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public GetCarByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
