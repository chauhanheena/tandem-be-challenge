namespace tandem_be_challenge.Exceptions
{
    public class InterenalServerException : Exception
    {
        public InterenalServerException(string errorMessage) : base (errorMessage) { }
    }
}
