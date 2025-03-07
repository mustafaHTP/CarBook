using CarBook.Application.Exceptions;
using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public DeleteModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<Model>(request.Id);

            await _repository.DeleteAsync(model);
        }
    }
}
