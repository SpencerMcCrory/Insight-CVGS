using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("WishList")]
public partial class WishList
{
    public int? MemberId { get; set; }

    public int? GameId { get; set; }

    [ForeignKey("GameId")]
    public virtual Game? Game { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member? Member { get; set; }
}
