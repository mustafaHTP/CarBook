using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var bannerToBeUpdated = await _repository.GetByIdAsync(updateBannerCommand.Id);
            //update here
            bannerToBeUpdated.VideoDescription = updateBannerCommand.VideoDescription;
            bannerToBeUpdated.Description = updateBannerCommand.Description;
            bannerToBeUpdated.VideoUrl = updateBannerCommand.VideoUrl;
            bannerToBeUpdated.Title = updateBannerCommand.Title;

            await _repository.UpdateAsync(bannerToBeUpdated);
        }
    }
}
