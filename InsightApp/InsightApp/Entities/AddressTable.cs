using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class AddressTable
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int AddressId { get; set; }


        [Required(ErrorMessage = "Please enter the street number")]
        public string StreetNumber { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        public string StreetName { get; set; }
        public string? Unit { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string Country { get; set; }
        public bool IsShipping { get; set; }=true;//default value
        public string? DelivaryInstructions { get; set; }
        public int MemberId { get; set; }//FK
        public ICollection<GameEvent>? Events { get; set; } // Nav to all Events
    }
}
