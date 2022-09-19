namespace tandem_be_challenge.Exceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string errorMessage) : base (errorMessage) { }
    }
}
