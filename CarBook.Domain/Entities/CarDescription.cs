using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class CarDescription : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Description { get; set; }
    }
}
