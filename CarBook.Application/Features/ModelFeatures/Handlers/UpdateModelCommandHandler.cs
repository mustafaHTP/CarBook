using CarBook.Application.Exceptions;
using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public UpdateModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Model).Name, request.Id.ToString());

            model.BrandId = request.BrandId;
            model.Name = request.Name;

            await _repository.UpdateAsync(model);
        }
    }
}
