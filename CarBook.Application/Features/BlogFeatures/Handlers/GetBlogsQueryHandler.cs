using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogsQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAllAsync();

            return blogs.Select(blog => new GetBlogsQueryResult
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
            }).ToList();
        }
    }
}
