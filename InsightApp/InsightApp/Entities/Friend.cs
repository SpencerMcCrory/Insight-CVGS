namespace InsightApp.Entities
{
    public class Friend
    {
        // Composite PK made of 2 FKs :
        public int MemberId { get; set; }
        public int FriendId { get; set; }

        // Nav props
        public Member? MemberFriend { get; set; }
    }
}
