using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Commands
{
    public class DeleteLocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
