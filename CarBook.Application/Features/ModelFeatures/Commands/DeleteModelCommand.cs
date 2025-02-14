using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Commands
{
    public class DeleteModelCommand : IRequest
    {
        public int Id { get; set; }
    }
}
