using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogByIdQueryDto
    {
        public string Includes { get; set; } = string.Empty;
    }
}
