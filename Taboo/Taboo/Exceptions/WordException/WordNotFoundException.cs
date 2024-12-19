namespace Taboo.Exceptions.WordException
{
    public class WordNotFoundException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public WordNotFoundException()
        {
            ErrorMessage = "Word Not Found";
        }

        public WordNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
