namespace CarBook.Domain.Entities
{
    public class CarDescription : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
    }
}
