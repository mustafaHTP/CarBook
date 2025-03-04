using MediatR;

namespace CarBook.Application.Features.CarFeatureFeatures.Commands
{
    public class UpdateCarFeatureCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
    }
}
