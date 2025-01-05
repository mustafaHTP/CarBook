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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var locationToBeUpdated = await _repository.GetByIdAsync(request.Id);

            //update here
            locationToBeUpdated.Name = request.Name;

            await _repository.UpdateAsync(locationToBeUpdated);
        }
    }
}
