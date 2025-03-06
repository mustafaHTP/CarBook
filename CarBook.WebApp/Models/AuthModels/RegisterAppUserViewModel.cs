using CarBook.Domain.Enums;

namespace CarBook.WebApp.Models.AuthModels
{
    public class RegisterAppUserViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; }
    }
}
