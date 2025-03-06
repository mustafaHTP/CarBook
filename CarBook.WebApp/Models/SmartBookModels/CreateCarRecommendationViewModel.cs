using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarBook.WebApp.Models
{
    public class CreateCarRecommendationViewModel
    {
        public string UserInput { get; set; } = null!;
    }
}
