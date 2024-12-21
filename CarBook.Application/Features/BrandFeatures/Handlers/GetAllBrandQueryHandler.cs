using CarBook.Application.Features.BrandFeatures.Queries;
using CarBook.Application.Features.BrandFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeatures.Handlers
{
    public class GetAllBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetAllBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllBrandQueryResult>> Handle()
        {
            var brands = await _repository.GetAllAsync();

            return brands.Select(b => new GetAllBrandQueryResult {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }
    }
}
