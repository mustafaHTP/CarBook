namespace CarBook.WebApi.Responses
{
    public record GenericApiResponse<T>(bool IsSuccessful, T? Result, ProblemDetails? ProblemDetails)
    {
        public static GenericApiResponse<T> Success(T? data)
        {
            return new(true, data, null);
        }

        public static GenericApiResponse<T> Success()
        {
            return new(true, default, null);
        }

        public static GenericApiResponse<T> Failure(ProblemDetails problemDetails)
        {
            return new(false, default, problemDetails);
        }

        public static GenericApiResponse<T> Failure(string title, int status, string detail)
        {
            return new(
                false,
                default,
                new ProblemDetails { Detail = detail, Status = status, Title = title });
        }
    }
}
