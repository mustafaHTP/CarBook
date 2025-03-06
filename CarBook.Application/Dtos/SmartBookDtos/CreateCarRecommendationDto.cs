using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarBook.WebApp.Models
{
    public class CreateCarRecommendationDto
    {
        public string UserInput { get; set; } = null!;
    }
}
