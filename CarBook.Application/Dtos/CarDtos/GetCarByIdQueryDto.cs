namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarByIdQueryDto
    {
        public bool IncludeModel { get; set; }
        public bool IncludeBrand { get; set; }
    }
}
