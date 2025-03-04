namespace CarBook.Application.Features.StatisticsFeatures.Results
{
    public class GetBlogHasMaxCommentCountQueryResult
    {
        public string? BlogTitle { get; set; }
        public int CommentCount { get; set; }
    }
}
