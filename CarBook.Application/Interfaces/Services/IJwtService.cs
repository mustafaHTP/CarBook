using CarBook.Application.Dtos.JwtDtos;

namespace CarBook.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(TokenRequestDto tokenRequestDto);
        string? GetClaimValue(string token, string claimType);
        DateTime? GetTokenExpirationDate(string token);
    }
}
