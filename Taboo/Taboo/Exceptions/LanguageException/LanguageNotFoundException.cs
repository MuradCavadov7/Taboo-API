namespace Taboo.Exceptions.LanguageException
{
    public class LanguageNotFoundException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage {get;}
        public LanguageNotFoundException()
        {
            ErrorMessage = "Language Not Found";
        }

        public LanguageNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
