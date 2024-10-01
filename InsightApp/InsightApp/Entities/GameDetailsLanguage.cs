namespace InsightApp.Entities
{
    public class GameDetailsLanguage
    {
        // Composite PK made of 2 FKs :
        public int GameId { get; set; }
        public int LanguageId { get; set; }

        // Nav props
        public Game? Game { get; set; }
        public LanguageTable? Language { get; set; }
    }
}
