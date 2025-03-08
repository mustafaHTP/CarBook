using CarBook.Application.Exceptions;
using CarBook.Application.Features.SocialMediaFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Handlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(SocialMedia), request.Id);

            socialMedia.Name = request.Name;
            socialMedia.Url = request.Url;
            socialMedia.Icon = request.Icon;

            await _repository.UpdateAsync(socialMedia);
        }
    }
}
