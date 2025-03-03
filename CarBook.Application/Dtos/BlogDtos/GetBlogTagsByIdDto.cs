using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogTagsByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
