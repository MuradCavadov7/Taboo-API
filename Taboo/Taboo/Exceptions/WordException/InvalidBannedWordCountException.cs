namespace Taboo.Exceptions.WordException
{
    public class InvalidBannedWordCountException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public InvalidBannedWordCountException()
        {
            ErrorMessage = "The number of banned words is limited";
        }

        public InvalidBannedWordCountException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
