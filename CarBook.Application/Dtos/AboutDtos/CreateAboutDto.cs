namespace CarBook.Application.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
