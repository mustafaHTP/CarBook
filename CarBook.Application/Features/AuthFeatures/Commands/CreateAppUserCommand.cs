using CarBook.Domain.Enums;
using MediatR;

namespace CarBook.Application.Features.AuthFeatures.Commands
{
    public class CreateAppUserCommand : IRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; }
    }
}
