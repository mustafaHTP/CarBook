namespace CarBook.Application.Dtos.StatisticsDtos
{
    public class GetBrandsCarCountDto
    {
        public string BrandName { get; set; } = null!;
        public int CarCount { get; set; }
    }
}
