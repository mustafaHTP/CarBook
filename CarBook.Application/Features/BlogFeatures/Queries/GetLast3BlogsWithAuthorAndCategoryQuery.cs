using CarBook.Application.Features.BlogFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Queries
{
    public class GetLast3BlogsWithAuthorAndCategoryQuery : IRequest<List<GetLast3BlogsWithAuthorAndCategoryQueryResult>>
    {
    }
}
