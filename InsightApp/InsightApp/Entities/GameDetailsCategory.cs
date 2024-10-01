namespace InsightApp.Entities
{
    public class GameDetailsCategory
    {
        // Composite PK made of 2 FKs :
        public int GameId { get; set; }
        public int CategoryId { get; set; }

        // Nav props
        public Game? Game { get; set; }
        public GameCategory? Category { get; set; }
    }
}
