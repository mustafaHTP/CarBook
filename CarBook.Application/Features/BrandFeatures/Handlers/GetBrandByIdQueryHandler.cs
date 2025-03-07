using CarBook.Application.Exceptions;
using CarBook.Application.Features.BrandFeatures.Queries;
using CarBook.Application.Features.BrandFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Handlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, GetBrandByIdQueryResult>
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Brand>(request.Id);
            var result = new GetBrandByIdQueryResult()
            {
                Id = brand.Id,
                Name = brand.Name,
            };

            return await Task.FromResult(result);
        }
    }
}
