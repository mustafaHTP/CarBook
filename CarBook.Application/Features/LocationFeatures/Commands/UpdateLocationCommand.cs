using MediatR;

namespace CarBook.Application.Features.LocationFeatures.Commands
{
    public class UpdateLocationCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
