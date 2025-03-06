using CarBook.Application.Dtos.SmartBookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Services
{
    public interface ISmartBookService
    {
        Task<SmartBookResponseDto> GetResponseAsync(SmartBookRequestDto smartBookRequestDto);
    }
}
