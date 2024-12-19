namespace Taboo.Exceptions.LanguageException
{
    public class LanguageExistException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage {get;}
        public LanguageExistException()
        {
            ErrorMessage = "Language already has added database";
        }

        public LanguageExistException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
