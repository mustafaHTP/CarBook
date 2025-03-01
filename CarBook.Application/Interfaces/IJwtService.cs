using CarBook.Application.Dtos.JwtDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(TokenRequestDto tokenRequestDto);
    }
}
