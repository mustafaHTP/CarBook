using CarBook.Application.Features.AuthFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.AuthFeatures.Queries
{
    public class LoginAppUserQuery : IRequest<LoginAppUserQueryResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
