namespace Taboo.Exceptions.WordException
{
    public class WordExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        public WordExistException()
        {
            ErrorMessage = "Word already has added database";
        }

        public WordExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

    }
}
