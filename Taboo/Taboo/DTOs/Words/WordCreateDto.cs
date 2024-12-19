using Taboo.DTOs.BannedWords;

namespace Taboo.DTOs.Words
{
    public class WordCreateDto
    {
        public string Text {  get; set; }
        public string LanguageCode { get; set; }
        public ICollection<string> BannedWords { get; set; }
    }
}
