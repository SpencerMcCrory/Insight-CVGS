using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("GameEvent")]
public partial class GameEvent
{
    [Key]
    public int EventId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string EventName { get; set; } = null!;

    [Unicode(false)]
    public string Details { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public int EvTypeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? EventLink { get; set; }

    public bool? IsDeleted { get; set; }

    public int? AddressId { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("GameEvents")]
    [NotMapped]
    public virtual AddressTable? Address { get; set; }

    [ForeignKey("EvTypeId")]
    [InverseProperty("GameEvents")]
    [NotMapped]
    public virtual EventType? EvType { get; set; }
}
