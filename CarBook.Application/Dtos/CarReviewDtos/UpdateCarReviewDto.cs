namespace CarBook.Application.Dtos.CarReviewDtos
{
    public class UpdateCarReviewDto
    {
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
