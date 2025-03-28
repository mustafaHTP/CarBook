﻿using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBlogAuthorCountQueryHandler : IRequestHandler<GetBlogAuthorCountQuery, GetBlogAuthorCountQueryResult>
    {
        private readonly IRepository<BlogAuthor> _repository;

        public GetBlogAuthorCountQueryHandler(IRepository<BlogAuthor> repository)
        {
            _repository = repository;
        }

        public Task<GetBlogAuthorCountQueryResult> Handle(GetBlogAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.Count();
            var result = new GetBlogAuthorCountQueryResult()
            {
                BlogAuthorCount = count
            };

            return Task.FromResult(result);
        }
    }
}
