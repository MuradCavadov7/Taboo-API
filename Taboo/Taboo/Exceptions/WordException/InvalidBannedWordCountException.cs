namespace Taboo.Exceptions.WordException
{
    public class InvalidBannedWordCountException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public InvalidBannedWordCountException()
        {
            ErrorMessage = "Banned words count must be equal 5";
        }

        public InvalidBannedWordCountException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
