namespace CarBook.Application.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
    }
}
