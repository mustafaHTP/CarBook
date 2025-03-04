using CarBook.Application.Features.BrandFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Handlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brandToBeCreated = new Brand()
            {
                Name = request.Name,
            };

            await _repository.CreateAsync(brandToBeCreated);
        }
    }
}
