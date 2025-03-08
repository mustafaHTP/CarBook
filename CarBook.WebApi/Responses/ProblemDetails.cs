namespace CarBook.WebApi.Responses
{
    public class ProblemDetails
    {
        public string Title { get; set; } = null!;
        public int Status { get; set; }
        public string Detail { get; set; } = null!;
    }
}
