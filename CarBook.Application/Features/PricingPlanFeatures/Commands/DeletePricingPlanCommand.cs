using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ReservationPricingFeatures.Commands
{
    public class DeletePricingPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}
