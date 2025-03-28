﻿using CarBook.Application.Features.SocialMediaFeatures.Queries;
using CarBook.Application.Features.SocialMediaFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Handlers
{
    public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediasQuery, List<GetSocialMediasQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediasQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }


        public async Task<List<GetSocialMediasQueryResult>> Handle(GetSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var socialMedias = await _repository.GetAllAsync();

            return socialMedias.Select(s => new GetSocialMediasQueryResult
            {
                Icon = s.Icon,
                Id = s.Id,
                Name = s.Name,
                Url = s.Url
            }).ToList();
        }
    }
}
