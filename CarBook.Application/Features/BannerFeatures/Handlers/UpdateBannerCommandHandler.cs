using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var bannerToBeUpdated = await _repository.GetByIdAsync(request.Id);

            // Update here
            bannerToBeUpdated.VideoDescription = request.VideoDescription;
            bannerToBeUpdated.Description = request .Description;
            bannerToBeUpdated.VideoUrl = request.VideoUrl;
            bannerToBeUpdated.Title = request.Title;

            await _repository.UpdateAsync(bannerToBeUpdated);
        }
    }
}
