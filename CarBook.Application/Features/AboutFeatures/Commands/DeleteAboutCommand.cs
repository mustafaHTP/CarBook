using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AboutFeatures.Commands
{
    public class DeleteAboutCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteAboutCommand(int id)
        {
            Id = id;
        }
    }
}
