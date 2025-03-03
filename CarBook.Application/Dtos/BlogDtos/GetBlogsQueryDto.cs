using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogsQueryDto
    {
        public string Includes { get; set; } = string.Empty;
        public int Limit { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
