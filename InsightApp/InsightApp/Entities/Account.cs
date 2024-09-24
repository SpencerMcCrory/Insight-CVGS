using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsightApp.Entities
{
    public class Account
    {
        public int AccountId { get; set; }


        // The "Remote" attr is a way to inform the client to call this action method
        [Required(ErrorMessage = "Please enter an email address")]
        [Remote("CheckEmail", "Validation")]  // "CheckEmail"==> action name,"Validation" ==> controller name ..this controller to get remote validn:
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? EmailAddress { get; set; }

        
        
        [Required(ErrorMessage = "Please enter a password")]
        [StringLength(25, ErrorMessage = "Your password cannot be more than 25 characters")]
        [Compare("PasswordConfirmation", ErrorMessage = "Your password entries must match")]
        public string? Password { get; set; }


        // The "NotMapped" attr means this field will not be mapped to a DB
        // field and therefore its values will not end up in the DB
        [Required(ErrorMessage = "Please re-enter your password for confirmation")]
        [Display(Name = "Confirm password")]
        [NotMapped()]
        public string? PasswordConfirmation { get; set; }

        public string? AccountType { get; set; }
        public bool AccountBlocked { get; set; } = false; //as a default value

    }
}
