namespace InsightApp.Entities
{
    public class Platform
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int PlatformId { get; set; }
        public string Name { get; set; }

        // following we are linking with the assocition tables
        public ICollection<MemberPlatformPref>? MemberPlatformPref { get; set; }
        public ICollection<GamePlatform>? GamePlatform { get; set; } 
    }
}
