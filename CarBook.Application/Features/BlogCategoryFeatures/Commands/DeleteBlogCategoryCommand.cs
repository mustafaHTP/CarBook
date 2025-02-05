using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Commands
{
    public class DeleteBlogCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
