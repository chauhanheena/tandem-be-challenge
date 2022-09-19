namespace tandem_be_challenge.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string errorMessage) : base(errorMessage) { }
    }
}
