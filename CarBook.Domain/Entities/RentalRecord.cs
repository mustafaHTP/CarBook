using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class RentalRecord : BaseEntity
    {
        public int PickUpLocationId { get; set; }
        public string PickupLocationName { get; set; } = string.Empty;
        public int ExpectedReturnLocationId { get; set; }
        public string ExpectedReturnLocationName { get; set; } = string.Empty;
        public int ReturnLocationId { get; set; }
        public string ReturnLocationName { get; set; } = string.Empty;
        public int CarId { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string PickUpDescription { get; set; } = string.Empty;
        public string ReturnDescription { get; set; } = string.Empty;
        public DateTime RentDate { get; set; }
        public DateTime ExceptedReturnDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;
        public Customer? Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
