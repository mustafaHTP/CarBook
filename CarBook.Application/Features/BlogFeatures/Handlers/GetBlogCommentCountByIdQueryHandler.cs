﻿using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using MediatR;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogCommentCountByIdQueryHandler : IRequestHandler<GetBlogCommentCountByIdQuery, GetBlogCommentCountByIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogCommentCountByIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<GetBlogCommentCountByIdQueryResult> Handle(GetBlogCommentCountByIdQuery request, CancellationToken cancellationToken)
        {
            int blogCommentCount = _repository.GetCommentCountById(request.Id);
            var result = new GetBlogCommentCountByIdQueryResult()
            {
                BlogCommentCount = blogCommentCount
            };

            return Task.FromResult(result);
        }
    }
}
