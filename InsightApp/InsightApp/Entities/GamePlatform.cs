using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("GamePlatform")]
public partial class GamePlatform
{
    [Key]
    public int PlatformId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string PlatformName { get; set; } = null!;
}
