using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Table("GameCategory")]
public partial class GameCategory
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string CategoryName { get; set; } = null!;
}
