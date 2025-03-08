using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Commands
{
    public class CreateBrandCommand : IRequest
    {
        public string Name { get; set; } = null!;
    }
}
