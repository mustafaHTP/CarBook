using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBlogHasMaxCommentCountQueryHandler : IRequestHandler<GetBlogHasMaxCommentCountQuery, GetBlogHasMaxCommentCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogHasMaxCommentCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBlogHasMaxCommentCountQueryResult> Handle(GetBlogHasMaxCommentCountQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetBlogHasMaxCommentCount();
            var result = new GetBlogHasMaxCommentCountQueryResult
            {
                BlogTitle = blog?.Title,
                CommentCount = blog?.BlogComments.Count ?? 0
            };

            return Task.FromResult(result);
        }
    }
}
