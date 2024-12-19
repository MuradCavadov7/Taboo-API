namespace Taboo.Entities
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string LanguageCode {  get; set; } = "az";
        public Language Language { get; set; }
        public ICollection<BannedWord> BannedWords { get; set; }

    }
}
