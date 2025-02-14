using MediatR;

namespace CarBook.Application.Features.ServiceFeatures.Commands
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }
    }
}
