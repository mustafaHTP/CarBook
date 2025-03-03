using CarBook.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.ModelDtos
{
    public class UpdateModelDto
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
    }
}
