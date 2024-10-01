using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("Game")]
public partial class Game
{
    [Key]
    public int GameId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string GameName { get; set; } = null!;

    [Unicode(false)]
    public string Details { get; set; } = null!;

    public double? Price { get; set; }

    public bool? PhysicalAvailable { get; set; }

    public bool? IsDeleted { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
