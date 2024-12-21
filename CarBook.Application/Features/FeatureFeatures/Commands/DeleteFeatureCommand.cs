using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FeatureFeatures.Commands
{
    public class DeleteFeatureCommand : IRequest
    {
        public int Id { get; set; }
    }
}
