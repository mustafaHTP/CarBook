using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Commands
{
    public class DeleteBannerCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteBannerCommand(int id)
        {
            Id = id;
        }
    }
}
