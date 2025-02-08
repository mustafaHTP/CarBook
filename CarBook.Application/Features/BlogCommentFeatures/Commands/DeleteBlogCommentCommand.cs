using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogCommentFeatures.Commands
{
    public class DeleteBlogCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
