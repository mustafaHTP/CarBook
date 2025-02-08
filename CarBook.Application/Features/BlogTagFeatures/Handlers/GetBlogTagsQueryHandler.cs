using CarBook.Application.Features.BlogTagFeatures.Queries;
using CarBook.Application.Features.BlogTagFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class GetBlogTagsQueryHandler : IRequestHandler<GetBlogTagsQuery, List<GetBlogTagsQueryResult>>
    {
        private readonly IRepository<BlogTag> _repository;

        public GetBlogTagsQueryHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogTagsQueryResult>> Handle(GetBlogTagsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();

            return blogs.Select(x => new GetBlogTagsQueryResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
