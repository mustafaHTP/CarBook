using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public CreateModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var model = new Model
            {
                BrandId = request.BrandId,
                Name = request.Name
            };

            await _repository.CreateAsync(model);
        }
    }
}
