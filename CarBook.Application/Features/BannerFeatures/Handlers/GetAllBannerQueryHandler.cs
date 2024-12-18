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
    public class GetAllBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetAllBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var banners = await _repository.GetAllAsync();

            return banners.Select(b => new GetBannerQueryResult()
            {
                Id = b.Id,
                Description = b.Description,
                Title = b.Title,
                VideoDescription = b.VideoDescription,
                VideoUrl = b.VideoUrl,
            }).ToList();
        }
    }
}
