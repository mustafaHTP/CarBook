using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class DeleteBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public DeleteBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBannerCommand deleteBannerCommand)
        {
            var bannerToBeDeleted = await _repository.GetByIdAsync(deleteBannerCommand.Id);
            await _repository.DeleteAsync(bannerToBeDeleted);
        }
    }
}
