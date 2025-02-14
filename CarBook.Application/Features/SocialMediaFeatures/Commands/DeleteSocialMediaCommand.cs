using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Commands
{
    public class DeleteSocialMediaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
