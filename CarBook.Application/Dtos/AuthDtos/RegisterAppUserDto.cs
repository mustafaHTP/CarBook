using CarBook.Domain.Enums;

namespace CarBook.Application.Dtos.AuthDtos
{
    public class RegisterAppUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; }
    }
}
