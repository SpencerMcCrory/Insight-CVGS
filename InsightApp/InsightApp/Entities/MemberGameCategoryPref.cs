namespace InsightApp.Entities
{
    public class MemberGameCategoryPref
    {
        // Composite PK made of 2 FKs :
        public int MemberId { get; set; }
        public int CategoryId { get; set; }

        // Nav props
        public Member? Member { get; set; }
        public GameCategory? Category { get; set; }
    }
}
