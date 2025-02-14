using CarBook.Application.Features.SocialMediaFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Queries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
