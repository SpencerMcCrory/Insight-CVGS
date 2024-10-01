namespace InsightApp.Entities
{
    public class MemberEventRegist
    {
        // Composite PK made of 2 FKs :
        public int MemberId { get; set; }
        public int EventId { get; set; }

        // Nav props
        public Member? Member { get; set; }
        public GameEvent? Event { get; set; }
    }
}
