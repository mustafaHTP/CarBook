using CarBook.Domain.Entities;

namespace CarBook.WebApp.Areas.Admin.Models.ModelModels
{
    public class CreateModelViewModel
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = null!;
    }
}
