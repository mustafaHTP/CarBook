using CarBook.Domain.Enums;

namespace CarBook.Application.Dtos.JwtDtos
{
    public class TokenRequestDto
    {
        public int AppUserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; }
    }
}
