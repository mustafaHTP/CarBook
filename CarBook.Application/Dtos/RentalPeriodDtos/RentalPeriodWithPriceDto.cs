namespace CarBook.Application.Dtos.RentalPeriodDtos
{
    public class RentalPeriodWithPriceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
