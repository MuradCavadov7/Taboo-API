namespace Taboo.DTOs.Words
{
    public class WordForGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> BannedWords { get; set; }
    }
}
