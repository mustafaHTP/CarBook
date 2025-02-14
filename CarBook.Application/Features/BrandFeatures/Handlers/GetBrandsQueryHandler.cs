﻿using CarBook.Application.Features.BrandFeatures.Queries;
using CarBook.Application.Features.BrandFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeatures.Handlers
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, List<GetBrandsQueryResult>>
    {
        private readonly IBrandRepository _repository;

        public GetBrandsQueryHandler(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandsQueryResult>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _repository.GetAllAsync(request.IncludeModels);
            var result = brands.Select(b => new GetBrandsQueryResult
            {
                Id = b.Id,
                Name = b.Name,
                Models = b.Models
            }).ToList();

            return result;
        }
    }
}
