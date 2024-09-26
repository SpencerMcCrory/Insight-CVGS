using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class Review
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int ReviewId { get; set; }
        
        [Required(ErrorMessage = "Please insert your review")]
        public string? Details { get; set; }
        public string? RejectReason { get; set; }

        public string? MemberId { get; set; } //FK
        public Member? Member { get; set; } //add a full EventType object as a 2nd prop
        public string? GameId { get; set; } //FK
        public Game? Game { get; set; } //add a full EventType object as a 2nd prop

        public string? StatusId { get; set; } //FK
        public ReviewStatus? ReviewStatus { get; set; } //add a full EventType object as a 2nd prop
    }
}
