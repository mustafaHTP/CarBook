using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Commands
{
    public class DeleteBannerCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBannerCommand(int id)
        {
            Id = id;
        }
    }
}
