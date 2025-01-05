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
