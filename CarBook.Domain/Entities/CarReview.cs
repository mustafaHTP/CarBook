namespace CarBook.Domain.Entities
{
    public class CarReview : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string Review { get; set; } = null!;
        public DateTime ReviewDate { get; set; }
        public int RatingStarCount { get; set; }
    }
}
