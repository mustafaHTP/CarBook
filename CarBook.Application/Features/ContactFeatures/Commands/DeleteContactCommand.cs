using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ContactFeatures.Commands
{
    public class DeleteContactCommand
    {
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
