using MediatR;

namespace CarBook.Application.Features.BrandFeatures.Commands
{
    public class DeleteBrandCommand : IRequest
    {
        public DeleteBrandCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
