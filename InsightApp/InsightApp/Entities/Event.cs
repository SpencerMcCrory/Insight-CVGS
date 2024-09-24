using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace InsightApp.Entities
{
    public class Event
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the event's detail.")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Please enter the start date.")]
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter the start time.")]
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }

        public string? EventLink { get; set; }

        public bool? IsDeleted { get; set; } = false; //default

        public string? EvTypeId { get; set; } //FK
        public EventType? EventType { get; set; } //add a full EventType object as a 2nd prop

        public int? AddressId { get; set; } //FK
        public Address? Address { get; set; } //add a full Address object as a 2nd prop

        public ICollection<MemberEventRegist>? MemberEventRegist { get; set; } // Nav to all members regestered
    }
}
