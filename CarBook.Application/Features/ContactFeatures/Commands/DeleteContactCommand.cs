using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Commands
{
    public class DeleteContactCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }
}
