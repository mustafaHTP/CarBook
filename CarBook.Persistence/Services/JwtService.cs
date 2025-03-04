using CarBook.Application.Dtos.JwtDtos;
using CarBook.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarBook.Persistence.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(TokenRequestDto tokenRequestDto)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, tokenRequestDto.AppUserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, tokenRequestDto.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, tokenRequestDto.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, tokenRequestDto.LastName),
                new Claim(ClaimTypes.Role, tokenRequestDto.AppUserRole.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string? GetClaimValue(string token, string claimType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            return securityToken?.Claims.First(claim => claim.Type == claimType).Value;
        }

        public DateTime? GetTokenExpirationDate(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var expClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;

            if (expClaim != null && long.TryParse(expClaim, out long expUnixTime))
            {
                return DateTimeOffset.FromUnixTimeSeconds(expUnixTime).UtcDateTime;
            }

            return null;
        }
    }
}
