using CarBook.Application.Features.LocationFeatures.Results;
using CarBook.Application.Features.SocialMediaFeatures.Queries;
using CarBook.Application.Features.SocialMediaFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
