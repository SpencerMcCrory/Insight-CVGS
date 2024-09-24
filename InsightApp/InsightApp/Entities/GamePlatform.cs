namespace InsightApp.Entities
{
    public class GamePlatform
    {
        // Composite PK made of 2 FKs :
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        // Nav props
        public Game? Game { get; set; }
        public Platform? Platform { get; set; }
    }
}
