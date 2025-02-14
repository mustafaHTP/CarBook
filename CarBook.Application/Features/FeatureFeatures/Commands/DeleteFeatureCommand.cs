using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Commands
{
    public class DeleteFeatureCommand : IRequest
    {
        public int Id { get; set; }
    }
}
