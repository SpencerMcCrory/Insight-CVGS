using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("OrderItem")]
public partial class OrderItem
{
    public int? OrderId { get; set; }

    public int? GameId { get; set; }

    public bool? IsShipped { get; set; }

    [ForeignKey("GameId")]
    public virtual Game? Game { get; set; }

    [ForeignKey("OrderId")]
    public virtual OrderTable? Order { get; set; }
}
