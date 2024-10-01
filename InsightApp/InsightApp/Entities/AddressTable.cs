using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("AddressTable")]
public partial class AddressTable
{
    [Key]
    public int AddressId { get; set; }

    public int MemberId { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string StreetName { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string StreetNumber { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? Province { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Country { get; set; } = null!;

    public bool? IsShipping { get; set; }

    [Unicode(false)]
    public string? DelivaryInstructions { get; set; }

    [InverseProperty("Address")]
    public virtual ICollection<GameEvent> GameEvents { get; set; } = new List<GameEvent>();

    [ForeignKey("MemberId")]
    [InverseProperty("AddressTables")]
    public virtual Member Member { get; set; } = null!;
}
