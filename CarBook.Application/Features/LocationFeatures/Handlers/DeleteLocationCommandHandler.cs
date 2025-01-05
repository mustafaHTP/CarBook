using CarBook.Application.Features.LocationFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.LocationFeatures.Handlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public DeleteLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToBeDeleted = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(locationToBeDeleted);
        }
    }
}
