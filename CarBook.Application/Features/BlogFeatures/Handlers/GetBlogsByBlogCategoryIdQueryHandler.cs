using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Helpers;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Application.RepositoryMappings;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogsByBlogCategoryIdQueryHandler : IRequestHandler<GetBlogsByBlogCategoryIdQuery, IEnumerable<GetBlogsByBlogCategoryIdQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetBlogsByBlogCategoryIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<GetBlogsByBlogCategoryIdQueryResult>> Handle(GetBlogsByBlogCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var includeExpressions = IncludeExpressionHelper.GetIncludeExpressions<Blog>(request.Includes, BlogMappings.IncludeMappings);

            var blogs = _repository.GetAllByBlogCategoryId(request.BlogCategoryId, includeExpressions);
            var result = blogs.Select(b => new GetBlogsByBlogCategoryIdQueryResult
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                BlogCategoryId = b.BlogCategoryId,
                BlogCategory = b.BlogCategory,
                BlogAuthorId = b.BlogAuthorId,
                BlogAuthor = b.BlogAuthor,
                Content = b.Content,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate
            });

            return Task.FromResult(result);
        }
    }
}
