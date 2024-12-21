using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Commands
{
    public class DeleteCarCommand
    {
        public int Id { get; set; }

        public DeleteCarCommand(int id)
        {
            Id = id;
        }
    }
}
