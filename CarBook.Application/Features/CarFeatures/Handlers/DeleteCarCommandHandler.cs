using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly IRepository<Car> _repository;

        public DeleteCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Car).Name, request.Id.ToString());

            await _repository.DeleteAsync(car);
        }
    }
}
