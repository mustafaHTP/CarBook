using CarBook.Application.Features.BlogAuthorFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogAuthorFeatures.Queries
{
    public class GetBlogAuthorsQuery : IRequest<List<GetBlogAuthorsQueryResult>>
    {
    }
}
