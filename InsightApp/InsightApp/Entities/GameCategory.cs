namespace InsightApp.Entities
{
    public class GameCategory
    {
        // Composite PK made of 2 FKs :
        public int GameId { get; set; }
        public int CategoryId { get; set; }

        // Nav props
        public Game? Game { get; set; }
        public Category? Category { get; set; }
    }
}
