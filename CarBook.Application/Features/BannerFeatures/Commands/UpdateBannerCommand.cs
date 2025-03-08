using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Commands
{
    public class UpdateBannerCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
    }
}
