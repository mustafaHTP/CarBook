using CarBook.Application.Exceptions;
using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Handlers
{
    public class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommand>
    {
        private readonly IRepository<Banner> _repository;

        public DeleteBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(Banner), request.Id);

            await _repository.DeleteAsync(banner);
        }
    }
}
