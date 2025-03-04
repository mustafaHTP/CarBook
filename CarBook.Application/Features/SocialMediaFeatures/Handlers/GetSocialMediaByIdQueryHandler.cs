using CarBook.Application.Features.SocialMediaFeatures.Queries;
using CarBook.Application.Features.SocialMediaFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Handlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetByIdAsync(request.Id);

            return new GetSocialMediaByIdQueryResult()
            {
                Id = socialMedia.Id,
                Icon = socialMedia.Icon,
                Url = socialMedia.Url,
                Name = socialMedia.Name,
            };
        }
    }
}
