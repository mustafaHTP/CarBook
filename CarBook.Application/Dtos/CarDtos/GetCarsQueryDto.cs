namespace CarBook.Application.Dtos.CarDtos
{
    public class GetCarsQueryDto
    {
        public bool IncludeModel { get; set; }
        public bool IncludeBrand { get; set; }
    }
}
