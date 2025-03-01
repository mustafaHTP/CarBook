using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.JwtDtos
{
    public class TokenRequestDto
    {
        public int AppUserId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public AppUserRole AppUserRole { get; set; }
    }
}
