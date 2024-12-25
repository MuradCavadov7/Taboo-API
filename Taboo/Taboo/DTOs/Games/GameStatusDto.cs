using Taboo.DTOs.Words;

namespace Taboo.DTOs.Games
{
    public class GameStatusDto
    {
        public byte Success {  get; set; }
        public byte Wrong { get; set; }
        public byte Pass {  get; set; }
        public byte MaxPass {  get; set; }
        public string LanguageCode {  get; set; }
        public Stack<WordForGameDto> Words { get; set; }
        public List<int> UseWordId {  get; set; }
    }
}
