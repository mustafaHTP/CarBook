using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogCategoryByIdQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetBlogCategoryByIdQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCategoryByIdQueryResult> Handle(GetBlogCategoryByIdQuery getBlogCategoryByIdQuery)
        {
            var blogCategory = await _repository.GetByIdAsync(getBlogCategoryByIdQuery.Id);

            return new GetBlogCategoryByIdQueryResult()
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name,
            };
        }
    }
}
