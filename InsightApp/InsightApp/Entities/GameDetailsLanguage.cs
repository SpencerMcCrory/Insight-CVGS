using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Entities;

[Keyless]
[Table("GameDetailsLanguage")]
public partial class GameDetailsLanguage
{
    public int? GameId { get; set; }

    public int? LanguageId { get; set; }

    [ForeignKey("GameId")]
    public virtual Game? Game { get; set; }

    [ForeignKey("LanguageId")]
    public virtual LanguageTable? Language { get; set; }
}
