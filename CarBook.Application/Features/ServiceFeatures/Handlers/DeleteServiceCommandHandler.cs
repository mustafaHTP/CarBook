using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
