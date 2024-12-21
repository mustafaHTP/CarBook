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
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery getBrandByIdQuery)
        {
            var brand = await _repository.GetByIdAsync(getBrandByIdQuery.Id);

            return new()
            {
                Id = brand.Id,
                Name = brand.Name,
            };
        }
    }
}
