using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Commands
{
    public class CreateModelCommand : IRequest
    {
        public int BrandId { get; set; }
        public required string Name { get; set; }
    }
}
