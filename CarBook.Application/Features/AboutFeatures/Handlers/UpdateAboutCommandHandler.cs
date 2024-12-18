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
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var aboutToBeUpdated = await _repository.GetByIdAsync(updateAboutCommand.Id);
            //update here
            aboutToBeUpdated.Description = updateAboutCommand.Description;
            aboutToBeUpdated.Title = updateAboutCommand.Title;
            aboutToBeUpdated.ImageUrl = updateAboutCommand.ImageUrl;

            await _repository.UpdateAsync(aboutToBeUpdated);
        }
    }
}
