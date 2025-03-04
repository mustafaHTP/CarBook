namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarDescriptionsByCarIdDto
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
