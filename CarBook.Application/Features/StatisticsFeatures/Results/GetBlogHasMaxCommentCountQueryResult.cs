using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.StatisticsFeatures.Results
{
    public class GetBlogHasMaxCommentCountQueryResult
    {
        public string? BlogTitle { get; set; }
        public int CommentCount { get; set; }
    }
}
