using MediatR;

namespace CarBook.Application.Features.CarFeatures.Commands
{
    public class DeleteCarCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteCarCommand(int id)
        {
            Id = id;
        }
    }
}
