using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddressFeatures.Commands
{
    public class DeleteFooterAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}
