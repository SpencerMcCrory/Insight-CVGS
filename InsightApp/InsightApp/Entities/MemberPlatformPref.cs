namespace InsightApp.Entities
{
    public class MemberPlatformPref
    {
        // Composite PK made of 2 FKs:
        public int MemberId { get; set; }
        public int PlatformId { get; set; }

        // Nav props
        public Member? Member { get; set; }
        public Platform? Platform { get; set; }
    }
}
