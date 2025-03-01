using CarBook.Application.Dtos.AuthDtos;
using CarBook.Application.Features.AuthFeatures.Commands;
using CarBook.Application.Features.AuthFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterAppUserDto registerAppUserDto)
        {
            var command = new CreateAppUserCommand
            {
                FirstName = registerAppUserDto.FirstName,
                LastName = registerAppUserDto.LastName,
                Email = registerAppUserDto.Email,
                Password = registerAppUserDto.Password,
                AppUserRole = registerAppUserDto.AppUserRole
            };

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginAppUserDto loginAppUserDto)
        {
            var query = new LoginAppUserQuery
            {
                Email = loginAppUserDto.Email,
                Password = loginAppUserDto.Password
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
