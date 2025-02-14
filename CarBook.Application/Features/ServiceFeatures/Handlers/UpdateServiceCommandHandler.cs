using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Interfaces;
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
            var serviceToBeUpdated = await _repository.GetByIdAsync(request.Id);
            //update here
            serviceToBeUpdated.Description = request.Description;
            serviceToBeUpdated.Title = request.Title;
            serviceToBeUpdated.IconUrl = request.IconUrl;

            await _repository.UpdateAsync(serviceToBeUpdated);
        }
    }
}
