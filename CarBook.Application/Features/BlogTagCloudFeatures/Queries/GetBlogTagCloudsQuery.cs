using CarBook.Application.Features.BlogTagCloudFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Queries
{
    public class GetBlogTagCloudsQuery : IRequest<List<GetBlogTagCloudsQueryResult>>
    {
    }
}
