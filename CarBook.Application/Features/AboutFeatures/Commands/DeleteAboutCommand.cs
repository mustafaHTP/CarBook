using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Commands
{
    public class DeleteAboutCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteAboutCommand(int id)
        {
            Id = id;
        }
    }
}
