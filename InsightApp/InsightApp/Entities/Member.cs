using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class Member
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Please enter the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter the last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter the display name")]
        public string DisplayName { get; set; }

        public string? Gender {get; set;}

        public DateOnly? DOB { get; set; }
        public bool RecievesEmails { get; set; } = false;//default value

        public string? PhoneNumber { get; set; }

        public int AccountId { get; set; } //FK
        public Account Account { get; set; }// to get the ability to have all the account detail in this model


        public ICollection<Address>? Address { get; set; } // Nav to all Addresses
        public ICollection<Order>? Order { get; set; }
        //public ICollection<Review>? Review { get; set; }


        //----following we are linking with the assocition tables

        public ICollection<Friend>? Friend { get; set; } // Nav to all friends in friend list
        public ICollection<WishList>? WishList { get; set; } // Nav to all games as in wish list
        public ICollection<MemberEventRegist>? MemberEventRegist { get; set; } // Nav to all registerd events
        public ICollection<MemberLanguagePref>? MemberLanguagePref { get; set; } // Nav to all preferd languages
        public ICollection<MemberGameCategoryPref>? MemberGameCategoryPref { get; set; } // Nav to all preferd game categories
        public ICollection<MemberPlatformPref>? MemberPlatformPref { get; set; } // Nav to all preferd game platforms

    }
}
