using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Commands
{
    public class UpdateBrandCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
