﻿using CarBook.Application.Dtos.JwtDtos;
using CarBook.Application.Features.AuthFeatures.Queries;
using CarBook.Application.Features.AuthFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Application.Interfaces.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.AuthFeatures.Handlers
{
    public class LoginAppUserQueryHandler : IRequestHandler<LoginAppUserQuery, LoginAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IJwtService _jwtService;

        public LoginAppUserQueryHandler(IRepository<AppUser> repository, IJwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        public Task<LoginAppUserQueryResult> Handle(LoginAppUserQuery request, CancellationToken cancellationToken)
        {
            //1.Check if user exists in the database
            //1.1Check password and email
            var user = _repository.FirstOrDefault(au => request.Email == au.Email && request.Password == au.Password);
            //1.2Check if user is active
            var result = new LoginAppUserQueryResult
            {
                IsAuthenticated = user != null
            };
            //2.Generate JWT Token
            if (user is not null)
            {
                var tokenRequestDto = new TokenRequestDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    AppUserId = user.Id,
                    AppUserRole = user.AppUserRole
                };
                result.Token = _jwtService.GenerateJwtToken(tokenRequestDto);
            }
            //3.Return the token

            return Task.FromResult(result);
        }
    }
}
