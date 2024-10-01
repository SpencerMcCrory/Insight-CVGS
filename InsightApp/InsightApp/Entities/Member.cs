using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("Member")]
[Index("AccountId", Name = "UQ__Member__349DA5A74185CF8E", IsUnique = true)]
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

    public bool? RecievesEmails { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public int? AccountId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Member")]
    public virtual Account? Account { get; set; }

    [InverseProperty("Member")]
    public virtual ICollection<AddressTable> AddressTables { get; set; } = new List<AddressTable>();

    [InverseProperty("Member")]
    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();

    [InverseProperty("Member")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
