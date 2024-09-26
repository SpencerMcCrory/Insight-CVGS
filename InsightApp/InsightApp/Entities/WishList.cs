namespace InsightApp.Entities
{
    public class WishList
    {
        // Composite PK made of 2 FKs :
        public int MemberId { get; set; }
        public int GameId { get; set; }

        // Nav props
        public Member? Member { get; set; }
        public Game? Game { get; set; }
    }
}
