using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class DeleteAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public DeleteAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAboutCommand deleteAboutCommand)
        {
            var aboutToBeDeleted = await _repository.GetByIdAsync(deleteAboutCommand.Id);
            await _repository.DeleteAsync(aboutToBeDeleted);
        }
    }
}
