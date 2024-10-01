using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("GameDetailsPlatform")]
public partial class GameDetailsPlatform
{
    public int? GameId { get; set; }

    public int? PlatformId { get; set; }

    [ForeignKey("GameId")]
    public virtual Game? Game { get; set; }

    [ForeignKey("PlatformId")]
    public virtual GamePlatform? Platform { get; set; }
}
