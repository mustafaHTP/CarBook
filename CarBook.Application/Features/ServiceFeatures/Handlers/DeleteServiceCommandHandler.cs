using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Handlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public DeleteServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToBeDeleted = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(serviceToBeDeleted);
        }
    }
}
