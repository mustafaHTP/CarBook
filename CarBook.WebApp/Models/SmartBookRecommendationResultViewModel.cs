using CarBook.Application.Dtos.CarDtos;

namespace CarBook.WebApp.Models
{
    public class SmartBookRecommendationResultViewModel
    {
        public GetCarByIdDto Car { get; set; } = null!;
        public string Reason { get; set; } = null!;
    }
}
