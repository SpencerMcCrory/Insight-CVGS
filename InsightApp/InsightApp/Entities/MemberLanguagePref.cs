namespace InsightApp.Entities
{
    public class MemberLanguagePref
    {
        // Composite PK made of 2 FKs :
        public int MemberId { get; set; }
        public int LanguageId { get; set; }

        // Nav props
        public Member? Member { get; set; }
        public Language? Language { get; set; }
    }
}
