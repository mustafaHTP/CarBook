using CarBook.Application.Exceptions;
using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Handlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Service).Name, request.Id.ToString());

            service.Description = request.Description;
            service.Title = request.Title;
            service.IconUrl = request.IconUrl;

            await _repository.UpdateAsync(service);
        }
    }
}
