using CarBook.Domain.Entities;

namespace CarBook.WebApp.Models
{
    public class UpdateCarFeatureAvailabilityViewModel
    {
        public int CarFeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
