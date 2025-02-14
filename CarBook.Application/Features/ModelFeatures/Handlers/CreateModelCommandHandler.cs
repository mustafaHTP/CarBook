using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public CreateModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var model = new Model
            {
                BrandId = request.BrandId,
                Name = request.Name
            };

            await _repository.CreateAsync(model);
        }
    }
}
