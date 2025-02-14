namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogByIdWithAuthorAndCategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogAuthorId { get; set; }
        public string BlogAuthorName { get; set; }
        public string BlockAuthorDescription { get; set; }
        public string BlockAuthorImageUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
    }
}
