namespace InsightApp.Entities
{
    public class Language
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int LanguageId { get; set; }
        public string Name { get; set; }

        // following we are linking with the assocition tables
        public ICollection<MemberLanguagePref>? MemberLanguagePref { get; set; }
        public ICollection<GameLanguage>? GameLanguage { get; set; }
    }
}
