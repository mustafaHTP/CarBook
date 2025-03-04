namespace CarBook.Application.Features.AuthFeatures.Results
{
    public class LoginAppUserQueryResult
    {
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
    }
}
