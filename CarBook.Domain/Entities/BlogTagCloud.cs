using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class BlogTagCloud : BaseEntity
    {
        public int BlogTagId { get; set; }
        public BlogTag BlogTag { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
