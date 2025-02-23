using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatureFeatures.Commands
{
    public class UpdateCarFeatureCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
    }
}
