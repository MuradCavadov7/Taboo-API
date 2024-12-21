using Taboo.Enums;

namespace Taboo.DTOs.Games
{
    public class GameCreateDto
    {
        public GameLevel GameLevel { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Seconds { get; set; }
    }
}
