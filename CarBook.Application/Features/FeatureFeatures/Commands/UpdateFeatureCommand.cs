using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Commands
{
    public class UpdateFeatureCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
