using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.AuthDtos
{
    public class LoginAppUserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
