using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ContactFeatures.Queries
{
    public class GetContactByIdQuery
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
