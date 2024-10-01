using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("Account")]
public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string EmailAddress { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string UserPassword { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string AccountType { get; set; } = null!;

    public bool? AccountBlocked { get; set; }

    [InverseProperty("Account")]
    public virtual Employee? Employee { get; set; }

    [InverseProperty("Account")]
    public virtual Member? Member { get; set; }
}
