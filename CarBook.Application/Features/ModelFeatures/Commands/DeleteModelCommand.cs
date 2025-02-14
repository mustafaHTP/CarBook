using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Commands
{
    public class DeleteModelCommand : IRequest
    {
        public int Id { get; set; }
    }
}
