using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetBlogsWithAuthorAndCategoryQuery : IRequest<List<GetBlogsWithAuthorAndCategoryQueryResult>>
    {
    }
}
