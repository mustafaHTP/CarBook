namespace CarBook.Application.Dtos.BlogDtos
{
    public class GetBlogsQueryDto
    {
        public string Includes { get; set; } = string.Empty;
        public int Limit { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
