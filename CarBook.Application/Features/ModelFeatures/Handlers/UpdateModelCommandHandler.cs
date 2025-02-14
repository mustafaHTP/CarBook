using CarBook.Application.Features.ModelFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ModelFeatures.Handlers
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public UpdateModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.Id);

            // Update here
            model.BrandId = request.BrandId;
            if(request.Name is not null)
            {
                model.Name = request.Name;
            }

            await _repository.UpdateAsync(model);
        }
    }
}
