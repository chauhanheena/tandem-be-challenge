namespace tandem_be_challenge.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string errorMessage) : base(errorMessage) { }
    }
}
