namespace CarBook.WebApi.Responses
{
    public record GenericApiResult<T>(bool IsSuccessFul, T? Data, ProblemDetails? ProblemDetails)
    {
        public static GenericApiResult<T> Success(T? data)
        {
            return new(true, data, null);
        }

        public static GenericApiResult<T> Failure(ProblemDetails problemDetails)
        {
            return new(false, default, problemDetails);
        }
    }
}
