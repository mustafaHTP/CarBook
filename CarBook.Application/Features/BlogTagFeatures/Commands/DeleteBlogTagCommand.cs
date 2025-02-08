using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagFeatures.Commands
{
    public class DeleteBlogTagCommand : IRequest
    {
        public int Id { get; set; }
    }
}
