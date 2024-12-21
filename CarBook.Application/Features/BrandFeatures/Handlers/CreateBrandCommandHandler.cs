using CarBook.Application.Features.BrandFeatures.Commands;
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
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand createBrandCommand)
        {
            var brandToBeCreated = new Brand()
            {
                Name = createBrandCommand.Name,
            };

            await _repository.CreateAsync(brandToBeCreated);
        }
    }
}
