using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Commands
{
    public class UpdateModelCommand : IRequest
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string? Name { get; set; }
    }
}
