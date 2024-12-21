using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BrandFeatures.Commands
{
    public class UpdateBrandCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
