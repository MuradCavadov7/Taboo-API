namespace Taboo.Exceptions.GameException
{
    public class GameAlreadyFinishedException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage {  get; }
        public GameAlreadyFinishedException()
        {
            ErrorMessage = "Game Already Finished";
        }

        public GameAlreadyFinishedException(string? message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
