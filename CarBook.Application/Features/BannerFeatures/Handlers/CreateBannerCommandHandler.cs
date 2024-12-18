using CarBook.Application.Features.AboutFeatures.Commands;
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
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand)
        {
            var bannerToBeCreated = new Banner()
            {
                Description = createBannerCommand.Description,
                Title = createBannerCommand.Title,
                VideoDescription = createBannerCommand.VideoDescription,
                VideoUrl = createBannerCommand.VideoUrl,
            };

            await _repository.CreateAsync(bannerToBeCreated);
        }
    }
}
