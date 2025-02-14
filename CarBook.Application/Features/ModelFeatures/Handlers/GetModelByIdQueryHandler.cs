using CarBook.Application.Features.ModelFeatures.Queries;
using CarBook.Application.Features.ModelFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, GetModelByIdQueryResult>
    {
        private readonly IRepository<Model> _repository;

        public GetModelByIdQueryHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task<GetModelByIdQueryResult> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.Id);
            var result = new GetModelByIdQueryResult()
            {
                Id = model.Id,
                BrandId = model.BrandId,
                Name = model.Name,
            };

            return await Task.FromResult(result);
        }
    }
}
