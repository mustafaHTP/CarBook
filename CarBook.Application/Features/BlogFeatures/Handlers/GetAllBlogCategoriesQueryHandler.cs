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
    public class GetAllBlogCategoriesQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetAllBlogCategoriesQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBlogCategoriesQueryResult>> Handle()
        {
            var blogCategories = await _repository.GetAllAsync();
            return blogCategories.Select(b => new GetAllBlogCategoriesQueryResult()
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }
    }
}
