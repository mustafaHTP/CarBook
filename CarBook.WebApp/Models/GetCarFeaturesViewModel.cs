using CarBook.Application.Dtos.CarDtos;

namespace CarBook.WebApp.Models
{
    public class GetCarFeaturesViewModel
    {
        public IEnumerable<GetCarFeaturesByCarIdDto> CarFeatures { get; set; } = [];
        public GetCarByIdDto? GetCarByIdDto { get; set; }
    }
}
