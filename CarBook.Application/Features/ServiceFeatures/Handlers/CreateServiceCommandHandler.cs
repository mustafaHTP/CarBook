using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Handlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var serviceToBeCreated = new Service()
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title,
            };

            await _repository.CreateAsync(serviceToBeCreated);
        }
    }
}
