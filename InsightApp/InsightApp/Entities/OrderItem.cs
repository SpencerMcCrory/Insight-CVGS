﻿namespace InsightApp.Entities
{
    public class OrderItem
    {
        // Composite PK made of 2 FKs :
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public bool IsShipped { get; set; }

        // Nav props
        public OrderTable? Order { get; set; }
        public Game? Game { get; set; }
    }
}
