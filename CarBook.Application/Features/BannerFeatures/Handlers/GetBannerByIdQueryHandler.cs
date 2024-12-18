using CarBook.Application.Features.AboutFeatures.Queries;
using CarBook.Application.Features.AboutFeatures.Results;
using CarBook.Application.Features.BannerFeatures.Queries;
using CarBook.Application.Features.BannerFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery)
        {
            var banner = await _repository.GetByIdAsync(getBannerByIdQuery.Id);

            return new()
            {
                Id = banner.Id,
                Description = banner.Description,
                Title = banner.Title,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl,
            };
        }
    }
}
