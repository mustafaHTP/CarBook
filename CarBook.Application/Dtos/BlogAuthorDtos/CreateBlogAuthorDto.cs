﻿namespace CarBook.Application.Dtos.BlogAuthorDtos
{
    public class CreateBlogAuthorDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
