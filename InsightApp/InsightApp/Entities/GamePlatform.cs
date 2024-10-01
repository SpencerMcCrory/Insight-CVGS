namespace InsightApp.Entities
{
    public class GamePlatform
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }

        // following we are linking with the assocition tables
        public ICollection<MemberPlatformPref>? MemberPlatformPrefs { get; set; }
        public ICollection<GameDetailsPlatform>? GameDetalsPlatforms { get; set; } 
    }
}
