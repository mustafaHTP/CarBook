using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.SmartBookDtos
{
    public class SmartBookResponseDto
    {
        public string? CarId { get; set; }
        public string? CarName { get; set; }
        public string? Reason { get; set; }
    }
}
