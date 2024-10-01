using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("GameDetailsCategory")]
public partial class GameDetailsCategory
{
    public int? GameId { get; set; }

    public int? CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual GameCategory? Category { get; set; }

    [ForeignKey("GameId")]
    public virtual Game? Game { get; set; }
}
