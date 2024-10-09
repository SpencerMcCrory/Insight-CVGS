using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[PrimaryKey("LoginProvider", "ProviderKey")]
public partial class AspNetUserLogin
{
    [Key]
    [StringLength(128)]
    public string LoginProvider { get; set; } = null!;

    [Key]
    [StringLength(128)]
    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    [StringLength(36)]
    [Unicode(false)]
    public string UserId { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserLogins")]
    public virtual AspNetUser User { get; set; } = null!;
}
