﻿namespace CarBook.Application.Dtos.BlogDtos
{
    public class BlogLiteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
