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
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand updateBrandCommand)
        {
            var brandToBeUpdated = new Brand()
            {
                Id = updateBrandCommand.Id,
                Name = updateBrandCommand.Name,
            };

            await _repository.UpdateAsync(brandToBeUpdated);
        }
    }
}
