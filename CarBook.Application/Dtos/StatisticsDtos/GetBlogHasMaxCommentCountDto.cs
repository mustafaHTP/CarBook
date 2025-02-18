using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.StatisticsDtos
{
    public class GetBlogHasMaxCommentCountDto
    {
        public string? BlogTitle { get; set; }
        public int CommentCount { get; set; }
    }
}
