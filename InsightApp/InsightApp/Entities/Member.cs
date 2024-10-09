using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("Member")]
[Index("AccountId", Name = "UQ__Member__349DA5A7538CB662", IsUnique = true)]
public partial class Member
{
    [Key]
    public int MemberId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? DisplayName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [Column("DOB")]
    public DateOnly? Dob { get; set; }

    public bool RecievesEmails { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [StringLength(36)]
    [Unicode(false)]
    public Guid AccountId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Member")]
    public virtual Account Account { get; set; } = null!;

    [InverseProperty("Member")]
    public virtual ICollection<AddressTable> AddressTables { get; set; } = new List<AddressTable>();

    [InverseProperty("FriendNavigation")]
    public virtual ICollection<Friend> FriendFriendNavigations { get; set; } = new List<Friend>();

    [InverseProperty("Member")]
    public virtual ICollection<Friend> FriendMembers { get; set; } = new List<Friend>();

    [InverseProperty("Member")]
    public virtual ICollection<MemberEventRegist> MemberEventRegists { get; set; } = new List<MemberEventRegist>();

    [InverseProperty("Member")]
    public virtual ICollection<MemberGameCategoryPref> MemberGameCategoryPrefs { get; set; } = new List<MemberGameCategoryPref>();

    [InverseProperty("Member")]
    public virtual ICollection<MemberLanguagePref> MemberLanguagePrefs { get; set; } = new List<MemberLanguagePref>();

    [InverseProperty("Member")]
    public virtual ICollection<MemberPlatformPref> MemberPlatformPrefs { get; set; } = new List<MemberPlatformPref>();

    [InverseProperty("Member")]
    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();

    [InverseProperty("Member")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Member")]
    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
