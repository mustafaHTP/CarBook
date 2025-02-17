﻿using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.Application.Features.StatisticsFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Handlers
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogCountQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var count = _repository.Count();
            var result = new GetBlogCountQueryResult
            {
                BlogCount = count
            };

            return Task.FromResult(result);
        }
    }
}
