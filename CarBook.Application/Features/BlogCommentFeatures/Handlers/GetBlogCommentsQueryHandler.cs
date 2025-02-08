using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogCommentFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class GetBlogCommentsQueryHandler : IRequestHandler<GetBlogCommentsQuery, List<GetBlogCommentsQueryResult>>
    {
        private readonly IRepository<BlogComment> _repository;

        public GetBlogCommentsQueryHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogCommentsQueryResult>> Handle(GetBlogCommentsQuery request, CancellationToken cancellationToken)
        {
            var blogComments = await  _repository.GetAllAsync();
            var result = blogComments.Select(x => new GetBlogCommentsQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                CreatedDate = x.CreatedDate,
                Content = x.Content,
                BlogId = x.BlogId
            }).ToList();

            return result;
        }
    }
}
