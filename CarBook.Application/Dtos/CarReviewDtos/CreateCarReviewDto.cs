namespace CarBook.Application.Dtos.CarReviewDtos
{
    public class CreateCarReviewDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
