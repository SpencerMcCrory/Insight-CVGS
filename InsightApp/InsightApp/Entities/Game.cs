﻿using System;
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
    public virtual ICollection<GameDetailsCategory> GameDetailsCategories { get; set; } = new List<GameDetailsCategory>();

    [InverseProperty("Game")]
    public virtual ICollection<GameDetailsLanguage> GameDetailsLanguages { get; set; } = new List<GameDetailsLanguage>();

    [InverseProperty("Game")]
    public virtual ICollection<GameDetailsPlatform> GameDetailsPlatforms { get; set; } = new List<GameDetailsPlatform>();

    [InverseProperty("Game")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Game")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Game")]
    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
