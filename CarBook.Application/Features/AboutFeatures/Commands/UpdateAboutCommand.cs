using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Commands
{
    public class UpdateAboutCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
