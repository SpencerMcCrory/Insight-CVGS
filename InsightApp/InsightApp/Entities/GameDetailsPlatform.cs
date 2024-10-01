namespace InsightApp.Entities
{
    public class GameDetailsPlatform
    {
        // Composite PK made of 2 FKs :
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        // Nav props
        public Game? Game { get; set; }
        public GamePlatform? Platform { get; set; }
    }
}
