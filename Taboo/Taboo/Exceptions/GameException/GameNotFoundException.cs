namespace Taboo.Exceptions.GameException
{
    public class GameNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public GameNotFoundException()
        {
            ErrorMessage = "Game Not Found";
        }

        public GameNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

    }
}
