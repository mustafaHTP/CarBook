using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Handlers
{
    public class DeleteCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public DeleteCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCarCommand deleteCarCommand)
        {
            var carToBeDeleted = await _repository.GetByIdAsync(deleteCarCommand.Id);

            await _repository.DeleteAsync(carToBeDeleted);
        }
    }
}
