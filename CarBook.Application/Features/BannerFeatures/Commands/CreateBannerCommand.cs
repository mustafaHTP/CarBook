using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Commands
{
    public class CreateBannerCommand : IRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
