using CarBook.Application.Features.BlogAuthorFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BlogAuthorFeatures.Queries
{
    public class GetBlogAuthorsQuery : IRequest<List<GetBlogAuthorsQueryResult>>
    {
        public bool IncludeBlogs { get; set; }
    }
}
