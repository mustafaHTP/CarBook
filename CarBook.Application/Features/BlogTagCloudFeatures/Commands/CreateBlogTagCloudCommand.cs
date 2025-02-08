using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Commands
{
    public class CreateBlogTagCloudCommand : IRequest
    {
        public int BlogTagId { get; set; }
        public int BlogId { get; set; }
    }
}
