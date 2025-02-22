﻿using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBlogCommentCountByBlogIdQueryHandler : IRequestHandler<GetBlogCommentCountByBlogIdQuery, GetBlogCommentCountByBlogIdQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogCommentCountByBlogIdQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBlogCommentCountByBlogIdQueryResult> Handle(GetBlogCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var blogCommentCount = _repository.GetBlogCommentCountByBlogId(request.BlogId);
            var result = new GetBlogCommentCountByBlogIdQueryResult
            {
                BlogCommentCount = blogCommentCount
            };

            return Task.FromResult(result);
        }
    }
}
