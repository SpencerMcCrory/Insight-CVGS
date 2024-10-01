using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class OrderTable
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
        public TimeOnly OrderTime { get; set; }
        public float TotalPayment { get; set; } = 0;
        public int MemberId { get; set; } //FK
        public Member? Member { get; set; } //add a full Member object as a 2nd prop

        public ICollection<OrderItem>? OrderItems { get; set; } // Nav to all order items
    }
}
