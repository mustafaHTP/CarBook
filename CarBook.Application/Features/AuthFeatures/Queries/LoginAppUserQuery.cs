using CarBook.Application.Features.AuthFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AuthFeatures.Queries
{
    public class LoginAppUserQuery : IRequest<LoginAppUserQueryResult>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
