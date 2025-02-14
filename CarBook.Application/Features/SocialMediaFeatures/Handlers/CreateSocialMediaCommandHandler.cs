using CarBook.Application.Features.SocialMediaFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Handlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMediaToBeCreated = new SocialMedia()
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url,
            };

            await _repository.CreateAsync(socialMediaToBeCreated);
        }
    }
}
