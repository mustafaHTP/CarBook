namespace CarBook.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public List<RentalCar>? RentalCars { get; set; }
    }
}
