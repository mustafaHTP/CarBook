using CarBook.Application.Features.AboutFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class GetAllAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAllAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllAboutQueryResult>> HandleAsync()
        {
            var values = await _repository.GetAllAsync();
            var queryResult = values.Select(x => new GetAllAboutQueryResult()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToList();

            return queryResult;
        }
    }
}
