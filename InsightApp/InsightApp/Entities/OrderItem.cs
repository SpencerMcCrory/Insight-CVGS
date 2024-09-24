namespace InsightApp.Entities
{
    public class OrderItem
    {
        // Composite PK made of 2 FKs :
        public int OrderId { get; set; }
        public int GameId { get; set; }

        // Nav props
        public Order? Order { get; set; }
        public Game? Game { get; set; }
    }
}
