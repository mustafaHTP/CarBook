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
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand>
    {
        private readonly IRepository<Model> _repository;

        public DeleteModelCommandHandler(IRepository<Model> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(model);
        }
    }
}
