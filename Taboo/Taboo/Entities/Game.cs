namespace Taboo.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public int BannedWordCount {  get; set; }
        public int FailCount {  get; set; }
        public int SkipCount {  get; set; }
        public TimeSpan Time { get; set; }
        public int? Score {  get; set; }
        public int SuccessAnswer {  get; set; }
        public int WrongAnswer {  get; set; }
        public string LanguageCode {  get; set; } = "az";
        public Language Language { get; set; }
    }
}
