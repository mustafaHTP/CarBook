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
    public class DeleteBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public DeleteBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBrandCommand deleteBrandCommand)
        {
            var brandToBeDeleted = await _repository.GetByIdAsync(deleteBrandCommand.Id);
            await _repository.DeleteAsync(brandToBeDeleted);
        }
    }
}
