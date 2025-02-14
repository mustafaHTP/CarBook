using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Commands
{
    public class CreateFeatureCommand : IRequest
    {
        public string Name { get; set; }
    }
}
