using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Commands
{
    public class CreateLocationCommand : IRequest
    {
        public string Name { get; set; }
    }
}
