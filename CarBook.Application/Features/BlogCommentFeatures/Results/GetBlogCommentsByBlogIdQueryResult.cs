﻿namespace CarBook.Application.Features.BlogCommentFeatures.Results
{
    public class GetBlogCommentsByBlogIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; } = null!;
        public int BlogId { get; set; }
    }
}
