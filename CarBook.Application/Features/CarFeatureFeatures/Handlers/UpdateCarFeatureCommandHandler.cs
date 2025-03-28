﻿using CarBook.Application.Exceptions;
using CarBook.Application.Features.CarFeatureFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CarFeatureFeatures.Handlers
{
    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeature = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(CarFeature).Name, request.Id.ToString());

            carFeature.Available = request.IsAvailable;

            await _repository.UpdateAsync(carFeature);
        }
    }
}
