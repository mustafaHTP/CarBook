using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogTagDtos
{
    public class GetBlogTagsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
