using CarBook.Application.Exceptions;
using CarBook.Application.Features.BrandFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Handlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Brand>(request.Id);

            // Update here
            brand.Name = request.Name;

            await _repository.UpdateAsync(brand);
        }
    }
}
