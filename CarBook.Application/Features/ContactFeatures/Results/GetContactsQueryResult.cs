namespace CarBook.Application.Features.ContactFeatures.Results
{
    public class GetContactsQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime SendDate { get; set; }
    }
}
