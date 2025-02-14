using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Commands
{
    public class CreateModelCommand : IRequest
    {
        public int BrandId { get; set; }
        public required string Name { get; set; }
    }
}
