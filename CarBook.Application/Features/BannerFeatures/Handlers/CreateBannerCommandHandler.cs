using CarBook.Application.Features.AboutFeatures.Commands;
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
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var bannerToBeCreated = new Banner()
            {
                Description = request.Description,
                Title = request.Title,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl,
            };

            await _repository.CreateAsync(bannerToBeCreated);
        }
    }
}
